using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Languages
{
    public static List<string> LANGUAGES = new List<string>{
        "English", "French"
    };
    public static string DEFAULT_LANGUAGE = LANGUAGES[0];
    public static string GetLanguage()
    {
        //Get the currently set language, otherwise get the default.
        return PlayerPrefs.GetString("language", DEFAULT_LANGUAGE);
    }
}
