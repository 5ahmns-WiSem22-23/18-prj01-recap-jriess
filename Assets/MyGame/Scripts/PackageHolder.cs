using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageHolder : MonoBehaviour
{
    bool holdingPackage;

    private void Awake()
    {
        holdingPackage = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        if(collision.tag == "Package")
        {
            holdingPackage = true;
            Destroy(collision.gameObject);
        }
    }
}
