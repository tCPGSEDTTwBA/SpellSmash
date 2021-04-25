using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCommand : GameCommand
{
    private float moveAmount = 0.5f;
    private GameObject gameObject;
    private Vector3 vector;

    public MoveCommand(GameObject gameObject, Vector3 vector)
    {
        this.gameObject = gameObject;
        this.vector = vector;
    }

    public override void Execute()
    {
        gameObject.transform.position -= vector*moveAmount;
    }
}
