using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public static int defaultTime = 90;
    private static int playerTime;
    private static float time = defaultTime;
    private bool running = false;

    public TextMeshProUGUI text;

    private void Awake()
    {
        playerTime = PlayerPrefs.GetInt("timelimit", defaultTime);
        time = playerTime;
    }

    public void ResetTimer()
    {
        time = playerTime;
    }

    public void ToggleTimer()
    {
        running = !running;
    }

    private void Display(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        var time = Mathf.FloorToInt(timeToDisplay);
        text.text = "Time: " + time.ToString();
    }

    private void Update()
    {
        if (running)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
            } else
            {
                time = 0;
            }
        }
        Display(time);
    }

    public float TimeLeft()
    {
        return time;
    }

    public void HideTimer()
    {
        text.enabled = false;
    }

    public void ShowTimer()
    {
        text.enabled = true;
    }

}
