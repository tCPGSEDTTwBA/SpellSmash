using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{

    private int ScoreTotal;
    public TextMeshProUGUI text;

    public int CalculateScore(string word)
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

        return score;
    }

    private void Update()
    {
        text.text = "Score: " + ScoreTotal.ToString();
    }

    public void AddToTotal(int score)
    {
        this.ScoreTotal += score;
    }

    public int GetScore()
    {
        return ScoreTotal;
    }
}
