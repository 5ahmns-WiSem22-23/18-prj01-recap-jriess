using UnityEngine;

public class PackageHolder : MonoBehaviour
{
    public bool holdingPackage;

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
