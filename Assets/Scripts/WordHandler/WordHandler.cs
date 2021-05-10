using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordHandler : MonoBehaviour
{
    public BlockStore blockStore;
    private List<GameObject> blocksToRemove;

    public string ProcessWord(GameObject block)
    {
        var letters = GetRow(block);
        var word = GenerateWord(letters);
        return IsWordCorrect(word);
    }

    public List<char> GetRow(GameObject block)
    {
        List<char> lettersOnRow = new List<char>();
        blocksToRemove = new List<GameObject>();

        if (blockStore.GetAllBlocks() != null && blockStore.GetAllBlocks().Count != 1)
        {
            var blocks = blockStore.GetAllBlocksByRow(block.transform.position.y).OrderBy(x => x.transform.position.x);
            for(int i = 0; i < blocks.Count(); i++)
            {

                lettersOnRow.Add(char.Parse(blocks.ElementAt(i).GetComponent<Block>().GetValue()));
                blocksToRemove.Add(blocks.ElementAt(i));

                if (blocks.ElementAt(i) == blocks.Last())
                {
                    break;
                }

                if (!(blocks.ElementAt(i).transform.position.x + 1 == blocks.ElementAt(i + 1).transform.position.x))
                {
                    lettersOnRow.Add(' ');
                }
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

    public string IsWordCorrect(string word)
    {
        var words = WordStore.GetWords();
        foreach(string validWord in words)
        {
            if (word.Contains(validWord))
            {
                return validWord;
            }
        }
        return string.Empty;
    }

    public List<GameObject> GetBlocksToDestroy()
    {
        return blocksToRemove;
    }
}
