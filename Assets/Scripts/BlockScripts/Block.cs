using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Determines the amount of time between the next move command is created. The lower the value the faster the commands are made.
    public float updateInterval;
    private float nextInterval = 0f;

    //Keeps track of where the block can move. Defaults to everywhere in the beginning.
    private Dictionary<string, bool> freeDirections = new Dictionary<string, bool>() {
        {"UP", true },
        {"DOWN", true },
        {"LEFT", true },
        {"RIGHT", true }
    };

    private void Update()
    {
        //Executes a 'MoveCommand' downwards every interval.
        if(Time.time >= nextInterval) {
            nextInterval += updateInterval;
            if(freeDirections["DOWN"]) {
                new MoveCommand(this.gameObject, DirectionDirectory.GetDirection("DOWN")).Execute();
            }
        }
    }
    public Dictionary<string, bool> GetFreeDirections()
    {
        return freeDirections;
    }

    public void SetFreeDirection(string key, bool value)
    {
        if (freeDirections.ContainsKey(key)) {
            freeDirections[key] = value;
        }
    }

}
