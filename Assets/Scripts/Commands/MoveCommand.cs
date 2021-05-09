using UnityEngine;

public class MoveCommand : GameCommand
{
    private Rigidbody2D rigidBody;
    private Vector2 vector;

    public MoveCommand(Rigidbody2D rigidbody, Vector2 vector)
    {
        this.rigidBody = rigidbody;
        this.vector = vector;
    }

    public override bool Execute()
    {
        rigidBody.MovePosition(rigidBody.position + vector);
        return true;
    }
}
