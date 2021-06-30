using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePrompts
{
    public string[] prompts = {
        "Nice!",
        "Well Done!",
        "Good Job!",
        "Spelltastic!",
        "Keep it up!",
        "Excellent!",
        "Spelltacular!",
        "Awesome!"
    };

    //Returns random prompt
    public string GetPrompt()
    {
        return prompts[Random.Range(0, prompts.Length)];
    }

}
