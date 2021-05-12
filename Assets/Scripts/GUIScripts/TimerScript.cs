using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public static float defaultTime = 100f;
    private static float time = defaultTime;
    private bool running = false;

    public TextMeshProUGUI text;

    private void Awake()
    {
        time = defaultTime;
    }

    public void ResetTimer()
    {
        time = defaultTime;
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

}
