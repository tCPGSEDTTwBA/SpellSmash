using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        Debug.Log("OnPause!");
        Debug.Log(context.performed);
        if (IsPaused)
        {
            Resume();
        } else
        {
            Pause();
        }
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    private void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

}
