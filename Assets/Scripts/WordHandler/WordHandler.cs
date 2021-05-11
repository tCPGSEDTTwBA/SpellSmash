using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordHandler : MonoBehaviour
{
    public BlockStore blockStore;

    public List<GameObject> ParseRow(GameObject block)
    {
        var letters = ParseRowFromBlock(block);
        var words = ParseWordListFromRow(letters);
        return ParseWordFromRow(words);
    }

    public List<GameObject> ParseRowFromBlock(GameObject block)
    {
        List<GameObject> blocksOnRow = new List<GameObject>();

        if (blockStore.GetAllBlocks() != null)
        {
            List<GameObject> blocks = blockStore.GetAllBlocksByRow(block.transform.position.y).OrderBy(x => x.transform.position.x).ToList();

            if(blocks.Count() <= 1)
            {
                return blocks;
            }

            for(int i = 0; i < blocks.Count(); i++)
            {

                blocksOnRow.Add(blocks.ElementAt(i));

                if (blocks.ElementAt(i) == blocks.Last())
                {
                    break;
                }

                if (!(blocks.ElementAt(i).transform.position.x + 1 == blocks.ElementAt(i + 1).transform.position.x))
                {
                    blocksOnRow.Add(null);
                }
            }
        }
        return blocksOnRow;
    }

    public List<List<GameObject>> ParseWordListFromRow(List<GameObject> blocksOnRow)
    {
        List<List<GameObject>> words = new List<List<GameObject>>();
        List<GameObject> blocks = new List<GameObject>();

        foreach(GameObject block in blocksOnRow)
        {
            if (block != null)
            {
                blocks.Add(block);
                if(blocksOnRow.Last().Equals(block))
                {
                    words.Add(blocks);
                    return words;
                }
            } else
            {
                words.Add(blocks);
                blocks = new List<GameObject>();
            }
        }

        return words;
    }

    public List<GameObject> ParseWordFromRow(List<List<GameObject>> blockWord)
    {
        string wordString = "";
        var words = WordStore.GetWords();
        foreach (List<GameObject> blockList in blockWord)
        {
            wordString = ParseWord(blockList);

            foreach (string validWord in words)
            {
                if (wordString.Contains(validWord))
                {
                    return FilterBlocks(blockList, validWord);
                }
            }

            //Set the string back to empty if the word was not found.
            wordString = string.Empty;
        }
        return new List<GameObject>();
    }

    //Finds and returns the exact sequence of blocks that matches the valid word
    private List<GameObject> FilterBlocks(List<GameObject> blocks, string match)
    {
        List<GameObject> filteredBlocks = new List<GameObject>();

        //No point in checking if we know there are not enough letters for a match, or if the match is empty.
        if (blocks.Count < match.Length || match == string.Empty)
        {
            return filteredBlocks;
        }

        char[] charArray = match.ToCharArray();
        
        int pointer = 0;
        int elementPointer = -1;
        while(elementPointer < blocks.Count()-1)
        {
            elementPointer++;
            string character = charArray[pointer].ToString();
            string blockValue = blocks.ElementAt(elementPointer).GetComponent<Block>().GetValue();
            if (character == blockValue)
            {
                filteredBlocks.Add(blocks.ElementAt(elementPointer));
                pointer++;
            } else
            {
                //If the pattern breaks, check the charArray from the beginning again.
                pointer = 0;
                filteredBlocks.Clear();
            }

            //If the pointer is equal to the length of array, there is a match
            if(pointer == charArray.Length)
            {
                return filteredBlocks;
            }
        }

        return new List<GameObject>();
    }

    public string ParseWord(List<GameObject> blocks)
    {
        string wordString = "";
        foreach(GameObject block in blocks)
        {
            if(block != null)
            {
                wordString += block.GetComponent<Block>().GetValue();
            }
        }
        return wordString;
    }
}
