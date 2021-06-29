using System.Collections.Generic;
using UnityEngine;

public class NextLetter : MonoBehaviour
{

    public static Letter GetNextLetter(List<Letter> alphabet)
    {
        int totalWeight = 0;

        foreach (var letter in alphabet)
        {
            totalWeight += letter.Weight;
        }

        int randomNumber = Random.Range(0, totalWeight);

        foreach (var letter in alphabet)
        {
            if (randomNumber < letter.Weight)
            {
                return letter;
            }
            randomNumber -= letter.Weight;
        }

        return null;
    }

}
