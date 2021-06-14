using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Letter;

public class nextLetter : MonoBehaviour
{
    private static Random _rnd = new Random();

    // Start is called before the first frame update
    void Start()
    {
        alphabet = createAlphabet(language);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string getNextLetter(List<string> alphabet, int totalWeight){

        // totalWeight is the sum of all alphabet' weight

        int randomNumber = _rnd.Next(0, totalWeight);

        string selectedLetter = null;
        foreach (Letter letter in alphabet)
        {
            if (randomNumber < letter.Weight)
            {
                return selectedLetter;
                break;
            }

            randomNumber = randomNumber - letter.Weight;
        }

        return "";

    }

}
