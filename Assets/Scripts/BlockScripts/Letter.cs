using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Letter
{
    public char Label { get; }
    public int Value { get; }

    public Letter(char label, int value)
    {
        Label = label;
        Value = value;
    }
}
