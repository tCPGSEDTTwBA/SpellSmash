using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float updateInterval;
    private float nextInterval = 0f;
    private bool canMove = true;

    private void Update()
    {
        if(Time.time >= nextInterval) {
            nextInterval += updateInterval;
            if(canMove) {
                new MoveCommand(this.gameObject, new Vector3(0, -1, 0)).Execute();
            }
        }
    }
    public bool CanMove()
    {
        return canMove;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision!");
        canMove = false;
    }
}
