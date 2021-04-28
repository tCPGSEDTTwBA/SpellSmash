using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    public UserInputHandler userInputHandler;
    public BlockStore blockStore;
    public ObjectSpawner blockSpawner;
    public GameObject block;

    private void Start()
    {
        GameObject block = SpawnBlock();
        StoreBlockObject(block);
        SetCurrentBlock(block);
    }

    public void SetCurrentBlock(GameObject block)
    {
        userInputHandler.setActiveObject(block);
    }

    /*
     * Instantiates a new block object using the generic object spawner.
     * Returns the block instance for utility - can be ignored if not required.
     */
    public GameObject SpawnBlock()
    {
        GameObject newBlockInstance = blockSpawner.SpawnGameObject(block, blockStore.transform);
        return newBlockInstance;
    }

    public void StoreBlockObject(GameObject block)
    {
        blockStore.AddBlock(block);
    }
}
