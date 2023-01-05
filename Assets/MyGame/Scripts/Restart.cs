using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void LoadAgain()
    {
        SceneManager.LoadScene(0);
    }
}
