using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rbPlayer;

    private void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
    }

    Vector2 GetInput()
    {
        float floatX = Input.GetAxisRaw("Horizontal");
        float floatY = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(floatX, floatY);
        return input;
    }
}
