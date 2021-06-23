using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Letter
{
    public char Value { get; }
    public int Weight { get; set; } = 1;

    public Letter(char value, int weight)
    {
        Value = value;
        Weight = weight;
    }
}
