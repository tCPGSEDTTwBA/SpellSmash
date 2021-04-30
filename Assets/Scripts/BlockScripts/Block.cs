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

    public Dictionary<string, bool> GetFreeDirections()
    {
        return freeDirections;
    }

    private void Update()
    {
        CheckCollision();
        if (Time.time >= nextInterval) {
            nextInterval += updateInterval;
            if (freeDirections["DOWN"]) {
                new MoveCommand(this.gameObject, DirectionDictionary.GetDirection("DOWN")).Execute();
            }
        }
    }

    public void CheckCollision()
    {
        //Cast a rays down, left and right
        List<RaycastHit2D> hits = new List<RaycastHit2D>() {
            Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity),
            Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity),
            Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity)
        };
        //For each ray, do this
        foreach(RaycastHit2D ray in hits) {
            //Uncomment if you want to see rays
            Debug.DrawLine(transform.position, ray.point);

            //If ray has hit something
            if(ray.collider != null) {
                //Get the distance from the block to the point of impact
                float distance = Vector2.Distance(ray.point, transform.position);

                /*If the distance is less than or equal to 0.5 (the width of the block) then the block is touching a collider
                If the distance is more than 0.5 then the block is not touching anything and should be free to move in that direction*/
                if (distance <= 0.5f) {
                    freeDirections[ray.collider.gameObject.name.ToUpper()] = false;
                } else if(distance > 0.5f) {
                    freeDirections[ray.collider.gameObject.name.ToUpper()] = true;
                }
            }
        }
    }
}
