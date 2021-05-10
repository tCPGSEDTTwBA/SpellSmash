using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{

    private int Score;

    public void CalculateScore(string word)
    {
        int score = 0;

        if (word != string.Empty)
        {
            var dictionary = LetterDictionary.getLetters();
            var letterArray = word.ToCharArray();

            foreach (char letter in letterArray)
            {
                score += dictionary[letter];
            }
        }

        Score += score;
    }

    public int GetScore()
    {
        return Score;
    }
}
