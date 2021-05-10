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

    private void Start()
    {
        InvokeRepeating("MoveBlocksDown", 0.25f, 0.25f);
    }

    private void MoveBlocksDown()
    {
        foreach(GameObject block in blocks)
        {
            if(block != null)
            {
                Block blockScript = block.GetComponent<Block>();
                if (blockScript.GetFreeDirections()[1])
                {
                    Debug.Log(block.name);
                    new MoveCommand(block.GetComponent<Rigidbody2D>(), Vector3.down).Execute();
                }
                
            }
        }
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
