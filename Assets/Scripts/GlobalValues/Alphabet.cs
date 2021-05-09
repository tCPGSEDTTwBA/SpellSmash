using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alphabet
{
    public static char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public static char GetRandomLetter()
    {
        return alphabet[Random.Range(0, alphabet.Length)];
    }

}