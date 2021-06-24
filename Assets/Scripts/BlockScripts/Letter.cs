using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Letter
{
    public char Value { get; }
    public int Weight { get; }
    public int Score { get; }


    public Letter(char value, int weight, int score)
    {
        Value = value;
        Weight = weight;
        Score = score;
    }
}
