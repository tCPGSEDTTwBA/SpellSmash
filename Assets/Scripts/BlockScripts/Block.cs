using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public bool isActive;

    /*
     * Using array for O(1) speed
     * Index 0: UP
     * Index 1: DOWN
     * Index 2: LEFT
     * Index 3: RIGHT
     */
    private bool[] freeDirections = new bool[] { true, true ,true ,true };

    public bool[] GetFreeDirections()
    {
        return freeDirections;
    }

    private void FixedUpdate()
    {
        CheckCollision();
    }

    public void CheckCollision()
    {
        RaycastHit2D[] raycasts = raycasts = new RaycastHit2D[] {
            Physics2D.Raycast(transform.position, Vector2.up, 0),
            Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity),
            Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity),
            Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity)
        };
        //For each ray, do this
        for (int x = 0; x < raycasts.Length; x++) {
            //Uncomment if you want to see rays
            //Debug.DrawLine(transform.position, raycasts[x].point);
            //If ray has hit something
            if(raycasts[x].collider != null) {
                //Get the distance from the block to the point of impact
                float distance = Vector2.Distance(raycasts[x].point, transform.position);

                /*If the distance is less than or equal to 0.5 (the width of the block) then the block is touching a collider
                If the distance is more than 0.5 then the block is not touching anything and should be free to move in that direction*/
                if (distance <= 0.5f) {
                    freeDirections[x] = false;
                } else if(distance > 0.5f) {
                    freeDirections[x] = true;
                }
            }
        }
    }
}
