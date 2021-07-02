using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TimerScript timer;
    public GameObject timeOutScreen;
    private bool GameActive = true;
    private bool EndlessMode = false;

    private void Awake()
    {
        //Endless mode is at position 1 (2nd value) from dropdown
        EndlessMode = PlayerPrefs.GetInt("gamemode", 0) == 1;
    }

    private void Start()
    {
        if(!EndlessMode) {
            timer.ShowTimer();
            timer.ToggleTimer();
        } else {
            timer.HideTimer();
        }
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
