using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStore : MonoBehaviour
{
    private List<GameObject> blocks;

    private void Awake()
    {
        blocks = new List<GameObject>();
    }

    public void AddBlock(GameObject block)
    {
        blocks.Add(block);
    }

    public List<GameObject> GetAllBlocks()
    {
        return blocks;
    }

    public List<GameObject> GetAllBlocksByRow(float rowPos)
    {
        List<GameObject> blocksOnRow = new List<GameObject>();
        foreach (var block in blocks)
        {
            if(block.transform.position.y == rowPos)
            {
                blocksOnRow.Add(block);
            }
        };

        return blocksOnRow;
    }
}
