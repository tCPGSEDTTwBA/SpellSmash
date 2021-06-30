using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{

    private int ScoreTotal;
    public TextMeshProUGUI text;
    [SerializeField]
    private Animator wizard;
    [SerializeField]
    private DialogueHandler dialogueHandler;

    public int CalculateScore(string word)
    {
        int score = 0;

        if (word != string.Empty)
        {
            var letters = Alphabet.GetScoreDictionary();
            var letterArray = word.ToCharArray();

            foreach (char letter in letterArray)
            {
                score += letters[letter];
            }
        }

        if(dialogueHandler != null) {
            if(wizard != null && score >= 3) {
                dialogueHandler.SetPrompt();
                wizard.SetTrigger("Popup");
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
