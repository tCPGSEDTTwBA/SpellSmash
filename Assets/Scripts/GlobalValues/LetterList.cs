using System.Collections;
using System.Collections.Generic;

static class LetterList
{
    private static readonly List<Letter> LETTERS = new List<Letter>()
    {
        {
            new Letter('A',1)
        },
        {
            new Letter('E',1)
        },
        {
            new Letter('I',1)
        },
        {
            new Letter('O',1)
        },
        {
            new Letter('U',1)
        },
        {
            new Letter('L',1)
        },
        {
            new Letter('N',1)
        },
        {
            new Letter('S',1)
        },
        {
            new Letter('T',1)
        },
        {
            new Letter('R',1)
        },
        {
            new Letter('D',1)
        },
        {
            new Letter('G',1)
        },
        {
            new Letter('B',1)
        },
        {
            new Letter('C',1)
        },
        {
            new Letter('M',1)
        },
        {
            new Letter('P',1)
        },
        {
            new Letter('F',1)
        },
        {
            new Letter('H',1)
        },
        {
            new Letter('V',1)
        },
        {
            new Letter('W',1)
        },
        {
            new Letter('Y',1)
        },
        {
            new Letter('K',1)
        },
        {
            new Letter('J',1)
        },
        {
            new Letter('X',1)
        },
        {
            new Letter('Q',1)
        },        
        {
            new Letter('Z',1)
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
            letterDictionary.Add(letter.Label, letter.Value);
        }

        return letterDictionary;
    }
}
