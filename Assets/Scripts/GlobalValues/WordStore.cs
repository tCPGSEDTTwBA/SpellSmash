using System.Collections.Generic;
using UnityEngine;

static class WordStore
{
    private static List<string> WORDS;
    private static readonly TextAsset WORDTEXTFILE = Resources.Load<TextAsset>("WordStore/WordList");
    private static readonly TextAsset FRENCHWORDTEXTFILE = Resources.Load<TextAsset>("WordStore/FrenchWordList");

    public static void GenerateWords() //language param
    {
        // if french use french text file
        WORDS = new List<string>(WORDTEXTFILE.text.Replace("\r\n", "\n").Split('\n'));
    }

    public static List<string> GetWords()
    {
        return WORDS;
    }
}
