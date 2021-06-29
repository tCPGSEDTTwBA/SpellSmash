using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Alphabet
{

    public static int initialQueueSize = 3;

    private static List<Letter> letterQueue = new List<Letter>();

    static Alphabet()
    {
        for(int x = 0; x < initialQueueSize; x++)
        {
            letterQueue.Add(GetWeightedLetter());
        }
    }

    public static Letter GetWeightedLetter()
    {
        return NextLetter.GetNextLetter(LetterList.GetLetters());
    }

    public static Letter GetNextLetter()
    {
        letterQueue.Add(GetWeightedLetter());
        Letter letterToReturn = letterQueue.ElementAt(0);
        letterQueue.RemoveAt(0);
        return letterToReturn;
    }

    public static List<Letter> GetLetterQueue()
    {
        return letterQueue;
    }

}
