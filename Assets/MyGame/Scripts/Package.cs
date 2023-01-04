using UnityEngine;

public class Package : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car")
        {
            DestroyPackage();
        }
    }

    void DestroyPackage()
    {
        Destroy(gameObject);
    }
}
