using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    public UserInputHandler userInputHandler;
    public BlockStore blockStore;
    public ObjectSpawner blockSpawner;
    public GameObject block;
    public WordHandler wordHandler;
    public ScoreHandler scoreHandler;

    private GameObject activeBlock;
    //The lower the update interval, the faster command are issued to the active block
    public float updateInterval;
    private float nextInterval = 0f;

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
            //Once you cannot keep moving down, you stop being the active block
            if(!block.GetFreeDirections()[1]) {
                StoreBlockObject(activeBlock);

                var word = wordHandler.ProcessWord(activeBlock);
                if(word != string.Empty)
                {
                    scoreHandler.CalculateScore(word);
                    DestroyBlocks(wordHandler.GetBlocksToDestroy());
                }
                
                activeBlock.layer = 0;
                ClearActiveBlock();
                activeBlock = SpawnBlock();
                userInputHandler.SetActiveObject(activeBlock);
            }
            //Send move command to block every interval
            if (Time.time >= nextInterval) {
                nextInterval += updateInterval;
                if (block.GetFreeDirections()[DirectionDictionary.GetIndex("DOWN")]) {
                    new MoveCommand(activeBlock.GetComponent<Rigidbody2D>(), DirectionDictionary.GetDirection("DOWN")).Execute();
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
        userInputHandler.ClearActiveObject();
    }

    private void DestroyBlocks(List<GameObject> stack)
    {
        foreach(GameObject block in stack)
        {
            Destroy(block);
        }
    }
}
