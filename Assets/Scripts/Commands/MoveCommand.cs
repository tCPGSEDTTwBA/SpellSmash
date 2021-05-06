using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCommand : GameCommand
{
    private float moveAmount = 0.5f;
    private Rigidbody2D rigidBody;
    private Vector3 vector;

    public MoveCommand(Rigidbody2D rigidbody, Vector3 vector)
    {
        this.rigidBody = rigidbody;
        this.vector = vector;
    }

    public override bool Execute()
    {
        rigidBody.MovePosition((Vector3)rigidBody.position + vector);
        return true;
    }
}
