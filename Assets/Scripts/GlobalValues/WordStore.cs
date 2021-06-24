using System.Collections.Generic;
using UnityEngine;

static class WordStore
{
    private static List<string> WORDS;
    private static readonly string PATH_PREFIX = "WordStore/WordList_";

    public static void GenerateWords(string language)
    {
        var filePath = PATH_PREFIX + language;
        TextAsset WordList = Resources.Load<TextAsset>(filePath);
        WORDS = new List<string>(WordList.text.Replace("\r\n", "\n").Split('\n'));
    }

    public static List<string> GetWords()
    {
        return WORDS;
    }
}
