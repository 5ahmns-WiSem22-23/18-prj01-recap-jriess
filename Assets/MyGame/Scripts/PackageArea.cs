using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageArea : MonoBehaviour
{
    [SerializeField] PackageManager pm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Car" && collision.gameObject.GetComponent<PackageHolder>() != null)
        {
            if (collision.gameObject.GetComponent<PackageHolder>().holdingPackage)
            {
                collision.gameObject.GetComponent<PackageHolder>().holdingPackage = false;
                pm.score += 1;
                pm.SpawnPackage(pm.packageSpawnPoints, pm.package);
            }
        }
    }
}
