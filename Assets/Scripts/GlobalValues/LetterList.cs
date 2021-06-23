using System.Collections;
using System.Collections.Generic;

static class LetterList
{
    private static readonly List<Letter> LETTERS = new List<Letter>()
    {
        {
            new Letter('A', 1)
        },
        {
            new Letter('E', 1)
        },
        {
            new Letter('I', 1)
        },
        {
            new Letter('O', 1)
        },
        {
            new Letter('U', 1)
        },
        {
            new Letter('L', 1)
        },
        {
            new Letter('N', 1)
        },
        {
            new Letter('S', 1)
        },
        {
            new Letter('T', 1)
        },
        {
            new Letter('R', 1)
        },
        {
            new Letter('D', 2)
        },
        {
            new Letter('G', 2)
        },
        {
            new Letter('B', 3)
        },
        {
            new Letter('C', 3)
        },
        {
            new Letter('M', 3)
        },
        {
            new Letter('P', 3)
        },
        {
            new Letter('F', 4)
        },
        {
            new Letter('H', 4)
        },
        {
            new Letter('V', 4)
        },
        {
            new Letter('W', 4)
        },
        {
            new Letter('Y', 4)
        },
        {
            new Letter('K', 5)
        },
        {
            new Letter('J', 8)
        },
        {
            new Letter('X', 8)
        },
        {
            new Letter('Q', 10)
        },        
        {
            new Letter('Z', 10)
        },
    };

    public static List<Letter> GetLetters()
    {
        return LETTERS;
    }

    public static Dictionary<char, int> GetLettersAsDictionary()
    {
        var letterDictionary = new Dictionary<char, int>();

        foreach(var letter in LETTERS)
        {
            letterDictionary.Add(letter.Value, letter.Weight);
        }

        return letterDictionary;
    }
}
