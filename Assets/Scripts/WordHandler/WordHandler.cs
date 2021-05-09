using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    string GenerateWord(char[] characters)
    {
        string word = "";

        foreach(char letter in characters)
        {
            word += letter;
        }

        return word;
    }

    bool IsWordCorrect(string word)
    {
        var words = WordStore.getWords();
        if (words.Contains(word))
        {
            return true;
        }
        return false;
    }

    int GetScore(string word)
    {
        int score = 0;

        var dictionary = LetterDictionary.getLetters();
        var letterArray = word.ToCharArray();

        foreach(char letter in letterArray)
        {
            score += dictionary[letter];
        }

        return score;
    }
}
