using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanguageSelector : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropDown;

    private void Start()
    {
        dropDown.AddOptions(Languages.LANGUAGES);
        //Display the currently selected language
        dropDown.value = Languages.LANGUAGES.IndexOf(Languages.GetLanguage());
    }

    public void ValueChanged(int value)
    {
        PlayerPrefs.SetString("language", Languages.LANGUAGES[value]);
    }
}
