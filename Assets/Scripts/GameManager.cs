using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TimerScript timer;
    public GameObject timeOutScreen;
    private bool GameActive = true;


    private void Start()
    {
        timer.ToggleTimer();
    }

    private void Update()
    {
        if(timer.TimeLeft() <= 0f && GameActive)
        {
            EndGame();
        } 
    }

    private void EndGame()
    {
        GameActive = false;
        timeOutScreen.SetActive(true);
        Time.timeScale = 0f;
    }

}
