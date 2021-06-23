using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Alphabet
{

    public static int initialQueueSize = 3;

    private static List<char> letterQueue = new List<char>();

    static Alphabet()
    {
        for(int x = 0; x < initialQueueSize; x++)
        {
            letterQueue.Add(GetWeightedLetter());
        }
    }

    public static char GetWeightedLetter()
    {
        return NextLetter.GetNextLetter(LetterList.GetLetters());
    }

    public static char GetNextLetter()
    {
        letterQueue.Add(GetWeightedLetter());
        char charToReturn = letterQueue.ElementAt(0);
        letterQueue.RemoveAt(0);
        return charToReturn;
    }

    public static List<char> GetLetterQueue()
    {
        return letterQueue;
    }

}
