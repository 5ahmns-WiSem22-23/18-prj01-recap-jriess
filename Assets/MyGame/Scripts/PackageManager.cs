using UnityEngine;

public class PackageManager : MonoBehaviour
{
    public Transform[] packageSpawnPoints;
    public GameObject package;
    public int score;

    private void Start()
    {
        score = 0;
        SpawnPackage(packageSpawnPoints, package);
    }

    public void SpawnPackage(Transform[] possibleSpawnpoints, GameObject package)
    {
        Instantiate(package, packageSpawnPoints[Random.Range(0, packageSpawnPoints.Length)]);
    }
}
