using UnityEngine;

public class ScoreHandler : MonoBehaviour
{

    private int Score;

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

    public void AddToTotalScore(int score)
    {
        Score += score;
    }

    public int GetScore()
    {
        return Score;
    }
}
