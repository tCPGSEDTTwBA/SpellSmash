using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    public UserInputHandler userInputHandler;
    public BlockStore blockStore;
    public ObjectSpawner blockSpawner;
    public GameObject block;

    private GameObject activeBlock;

    private void Start()
    {
        GameObject newBlock = SpawnBlock();
        userInputHandler.SetActiveObject(newBlock);
        activeBlock = newBlock;
    }

    private void Update()
    {
        if(activeBlock != null) {
            //If a block reaches the bottom, it is no longer the active block
            if (activeBlock.GetComponent<Block>().GetFreeDirections()["DOWN"] == false) {
                ClearActiveBlock();
                activeBlock = SpawnBlock();
                userInputHandler.SetActiveObject(activeBlock);
            }
        }
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

    public GameObject GetActiveBlock()
    {
        return this.activeBlock;
    }

    public void ClearActiveBlock()
    {
        this.activeBlock = null;
    }
}
