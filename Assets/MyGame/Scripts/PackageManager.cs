using UnityEngine;
using UnityEngine.UI;

public class PackageManager : MonoBehaviour
{
    public Transform[] packageSpawnPoints;
    public GameObject package;
    public int score;
    [SerializeField] Text scoreText;
    [SerializeField] Text scoreTextFinal;

    private void Start()
    {
        score = 0;
        SpawnPackage(packageSpawnPoints, package);
    }

    public void SpawnPackage(Transform[] possibleSpawnpoints, GameObject package)
    {
        Instantiate(package, packageSpawnPoints[Random.Range(0, packageSpawnPoints.Length)].position, Quaternion.identity);
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        scoreTextFinal.text = "Your Score: " + score.ToString();
    }
}
