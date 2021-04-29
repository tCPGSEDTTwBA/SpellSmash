using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxHandler : MonoBehaviour
{
    public BlockHandler blockHandler;

    public void ReportCollision(string direction, bool value)
    {
        GameObject activeBlock = blockHandler.GetActiveBlock();
        Debug.Log(activeBlock);
        if (activeBlock != null) {
            Debug.Log(direction + " " + value);
            activeBlock.GetComponent<Block>().SetFreeDirection(direction.ToUpper(), value);
        }
    }

}
