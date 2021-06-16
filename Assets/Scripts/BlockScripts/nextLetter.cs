using System.Collections.Generic;
using UnityEngine;

public class NextLetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //alphabet = createAlphabet(language);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string getNextLetter(List<Letter> alphabet, int totalWeight){

        // totalWeight is the sum of all alphabet' weight

        //int randomNumber = _rnd.Next(0, totalWeight);
        int randomNumber = Random.Range(0, totalWeight);

        string selectedLetter = null;
        foreach(Letter letter in alphabet)
        {
            if (randomNumber < letter.weight)
            {
                return selectedLetter;
            }

            randomNumber = randomNumber - letter.weight;
        }

        return "";
    }

}
