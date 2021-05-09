using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordHandler : MonoBehaviour
{
    public BlockStore blockStore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<char> GetRow(GameObject block)
    {
        List<char> lettersOnRow = new List<char>();
        if (blockStore.GetAllBlocks() != null)
        {
            var blocks = blockStore.GetAllBlocksByRow(block.transform.position.y).OrderBy(x => x.transform.position.x);

            foreach (var blockOnRow in blocks)
            {
                lettersOnRow.Add(char.Parse(blockOnRow.GetComponent<Block>().GetValue()));
            }

            return lettersOnRow;
        }
        return new List<char>();
    }

    public string GenerateWord(List<char> characters)
    {
        string word = "";

        foreach(char letter in characters)
        {
            word += letter;
        }

        return word;
    }

    public bool IsWordCorrect(string word)
    {
        var words = WordStore.getWords();
        if (words.Contains(word))
        {
            return true;
        }
        return false;
    }

    public int GetScore(string word)
    {
        int score = 0;

        var dictionary = LetterDictionary.getLetters();
        var letterArray = word.ToCharArray();

        foreach(char letter in letterArray)
        {
            score += dictionary[letter];
        }

        return score;
    }
}
