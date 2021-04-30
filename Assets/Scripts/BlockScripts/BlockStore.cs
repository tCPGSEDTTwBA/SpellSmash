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
}
