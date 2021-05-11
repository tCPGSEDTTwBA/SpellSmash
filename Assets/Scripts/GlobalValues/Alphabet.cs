using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Alphabet
{
    //public static char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    public static char[] alphabet = "TEST".ToCharArray();

    public static int initialQueueSize = 3;

    private static List<char> letterQueue = new List<char>();

    static Alphabet()
    {
        for(int x = 0; x < initialQueueSize; x++)
        {
            letterQueue.Add(GetRandomLetter());
        }
    }

    public static char GetRandomLetter()
    {
        return alphabet[Random.Range(0, alphabet.Length)];
    }

    public static char GetNextLetter()
    {
        letterQueue.Add(GetRandomLetter());
        char charToReturn = letterQueue.ElementAt(0);
        letterQueue.RemoveAt(0);
        return charToReturn;
    }

    public static List<char> GetLetterQueue()
    {
        return letterQueue;
    }

}
