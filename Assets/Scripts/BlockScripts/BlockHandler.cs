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
    private float updateInterval = 0.25f;
    private float nextInterval = 0;

    private void Start()
    {
        GameObject newBlock = SpawnBlock();
        userInputHandler.SetActiveObject(newBlock);
        activeBlock = newBlock;
    }

    private void FixedUpdate()
    {
        if (activeBlock != null) {
            Block block = activeBlock.GetComponent<Block>();
            //If a block reaches the bottom, it is no longer the active block
            if (!block.GetFreeDirections()["DOWN"]) {
                ClearActiveBlock();
                activeBlock = SpawnBlock();
                userInputHandler.SetActiveObject(activeBlock);
            } else {
                if (Time.time >= nextInterval) {
                    nextInterval += updateInterval;
                    if (block.GetFreeDirections()["DOWN"]) {
                        new MoveCommand(activeBlock, DirectionDictionary.GetDirection("DOWN")).Execute();
                    }
                }
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
        newBlockInstance.name = newBlockInstance.name + Random.Range(0, int.MaxValue);
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
