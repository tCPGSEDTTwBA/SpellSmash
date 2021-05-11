using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transition;
    public Animator wizard;
    public float transitionTime = 1.5f;

    public void PlayGame()
    {
        WordStore.GenerateWords();
        StartCoroutine(LoadLevel("Level"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadLevel(string levelName)
    {
        wizard.SetTrigger("Drop");
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);
    }

}
