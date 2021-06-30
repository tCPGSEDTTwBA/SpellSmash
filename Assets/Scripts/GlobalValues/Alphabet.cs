using System.Collections;
using System.Collections.Generic;

static class Alphabet
{
    private static readonly List<Letter> LETTERS = new List<Letter>()
    {
        {
            new Letter('A', 43, 1)
        },
        {
            new Letter('E', 57, 1)
        },
        {
            new Letter('I', 38, 1)
        },
        {
            new Letter('O', 37, 1)
        },
        {
            new Letter('U', 19, 1)
        },
        {
            new Letter('L', 28,  1)
        },
        {
            new Letter('N', 34, 1)
        },
        {
            new Letter('S', 29, 1)
        },
        {
            new Letter('T', 35, 1)
        },
        {
            new Letter('R', 37, 1)
        },
        {
            new Letter('D', 17, 2)
        },
        {
            new Letter('G', 13, 2)
        },
        {
            new Letter('B', 11, 3)
        },
        {
            new Letter('C', 23, 3)
        },
        {
            new Letter('M', 15, 3)
        },
        {
            new Letter('P', 16, 3)
        },
        {
            new Letter('F', 9, 4)
        },
        {
            new Letter('H', 15, 4)
        },
        {
            new Letter('V', 5, 4)
        },
        {
            new Letter('W', 7, 4)
        },
        {
            new Letter('Y', 9, 4)
        },
        {
            new Letter('K', 6, 5)
        },
        {
            new Letter('J', 1, 8)
        },
        {
            new Letter('X', 1, 8)
        },
        {
            new Letter('Q', 1, 10)
        },        
        {
            new Letter('Z', 1, 10)
        },
    };

    public static List<Letter> GetLetters()
    {
        return LETTERS;
    }

    public static Dictionary<char, int> GetScoreDictionary()
    {
        var letterDictionary = new Dictionary<char, int>();

        foreach(var letter in LETTERS)
        {
            letterDictionary.Add(letter.Value, letter.Score);
        }

        return letterDictionary;
    }
}
