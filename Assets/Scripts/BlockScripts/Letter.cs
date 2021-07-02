using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Letter
{
    public char Value { get; }
    public int Weight { get; }
    public int Score { get; }

    public bool isMultiplier { get; }

    public Letter(char value, int weight, int score)
    {
        Value = value;
        Weight = weight;
        isMultiplier = Random.Range(0f, 1f) < 0.25f;
        if(isMultiplier) {
            score = score * 2;
;       }
        Score = score;
    }
}
