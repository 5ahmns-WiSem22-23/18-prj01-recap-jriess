using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float baseTime;
    [SerializeField] float currentTime;   
    bool over;
    [SerializeField] GameObject timeShowFinal;
    [SerializeField] Text timeText;

    private void Start()
    {
        currentTime = baseTime;
        over = false;
        timeShowFinal.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = 0;
            if (!over)
            {
                Over();
            }          
        }
        int showTime = (int)currentTime;
        timeText.text = "Time: " + showTime.ToString();
    }

    private void Over()
    {
        over = true;
        timeShowFinal.SetActive(true);
        Time.timeScale = 0;
    }
}
