using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float accelerationFactor;
    [SerializeField] float baseAccelerationFactor;
    [SerializeField] float turnFactor;
    [SerializeField] float driftFactor;
    [SerializeField] float maxSpeed;
    [SerializeField] float baseMaxSpeed;
    [SerializeField] float boostAmount;
    [SerializeField] float maxSpeedBoost;

    float accelerationInput;
    float steeringInput;

    float rotationAngle;

    float velocityForward;

    Rigidbody2D rbCar;
    Vector2 forceVector;

    private void Awake()
    {
        rbCar = GetComponent<Rigidbody2D>();
        baseAccelerationFactor = accelerationFactor;
        baseMaxSpeed = maxSpeed;
    }

    private void FixedUpdate()
    {
        ApplyForce();

        HandleDrifting();

        ApplySteering();
    }

    void ApplyForce()
    {
        velocityForward = Vector2.Dot(transform.up, rbCar.velocity);

        if(velocityForward > maxSpeed && accelerationInput > 0)
        {
            return;
        }

        if (velocityForward < -maxSpeed * 0.5f && accelerationInput < 0)
        {
            return;
        }

        if (rbCar.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
        {
            return;
        }

        if (accelerationInput == 0)
        {
            rbCar.drag = Mathf.Lerp(rbCar.drag, 3, Time.fixedDeltaTime * 3);
        }
        else
        {
            rbCar.drag = 0;
        }

        forceVector = transform.up * accelerationInput * accelerationFactor;
        rbCar.AddForce(forceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        float speedAllowingToTurn = (rbCar.velocity.magnitude / 8);
        speedAllowingToTurn = Mathf.Clamp01(speedAllowingToTurn);

        

        if(Vector2.Dot(transform.up, rbCar.velocity) > 0)
        {
            rotationAngle -= steeringInput * turnFactor * speedAllowingToTurn;
        }
        else if(Vector2.Dot(transform.up, rbCar.velocity) < 0)
        {
            rotationAngle -= steeringInput * -turnFactor * speedAllowingToTurn;
        }

        rbCar.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
    }

    void HandleDrifting()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rbCar.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rbCar.velocity, transform.right);

        rbCar.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    IEnumerator Boost()
    {
        maxSpeed = maxSpeedBoost;
        Vector2 currentVector = rbCar.velocity;
        currentVector.Normalize();
        rbCar.velocity = currentVector * boostAmount;
        yield return new WaitForSeconds(0.16f);
        maxSpeed = baseMaxSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Boost")
        {
            StartCoroutine(Boost());
        }
    }
}
