using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        return blocks.Where(block => block != null && block.transform.position.y == rowPos).ToList();
    }
}
