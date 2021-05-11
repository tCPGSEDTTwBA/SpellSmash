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
                StoreBlock(activeBlock);
                List<GameObject> wordBlocks = wordHandler.ParseRow(activeBlock);
                string wordString = wordHandler.ParseWord(wordBlocks);
                if(wordString != string.Empty)
                {
                    var score = scoreHandler.CalculateScore(wordString);
                    scoreHandler.AddToTotalScore(score);
                }
                if(wordBlocks != null && wordBlocks.Count > 0)
                {
                    wordBlocks.ForEach(x => Destroy(x));
                }

                activeBlock.layer = 0;
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

    public void StoreBlock(GameObject block)
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
}
