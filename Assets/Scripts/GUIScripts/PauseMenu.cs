using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject pauseMenu;

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnPause();
        } 
    }

    public void OnPause()
    {
        if (IsPaused)
        {
            Resume();
        }
        else if (!IsPaused)
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
