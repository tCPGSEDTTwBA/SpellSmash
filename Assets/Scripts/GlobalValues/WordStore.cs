using System.Collections.Generic;
using UnityEngine;

static class WordStore
{
    private static List<string> WORDS;
    private static readonly TextAsset WORDTEXTFILE = Resources.Load<TextAsset>("WordStore/WordList");

    public static void GenerateWords()
    {
        WORDS = new List<string>(WORDTEXTFILE.text.Replace("\r\n", "\n").Split('\n'));
    }

    public static List<string> GetWords()
    {
        return WORDS;
    }
}
