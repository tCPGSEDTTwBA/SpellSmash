using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    // Seperate class to make it easy to switch prompts if needed
    private DialoguePrompts dialoguePrompts = new DialoguePrompts();
   [SerializeField]
    private TextMeshProUGUI text;

    public void SetPrompt()
    {
        text.text = dialoguePrompts.GetPrompt();
    }

}
