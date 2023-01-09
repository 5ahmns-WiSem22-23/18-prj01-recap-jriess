using UnityEngine;

public class PackageHolder : MonoBehaviour
{
    public bool holdingPackage;
    public GameObject packageInCar;

    private void Update()
    {
        if (holdingPackage)
        {
            packageInCar.SetActive(true);
        }
        else
        {
            packageInCar.SetActive(false);
        }
    }
    private void Awake()
    {
        holdingPackage = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Package")
        {
            holdingPackage = true;
        }
    }
}
