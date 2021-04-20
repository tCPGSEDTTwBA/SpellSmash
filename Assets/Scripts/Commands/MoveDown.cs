using CommandPattern;
using UnityEngine;

public class MoveDown : GameCommand
{
    public override void Execute(Transform boxTrans, GameCommand command)
    {
        Move(boxTrans);

        GameInputHandler.oldCommands.Add(command);
    }

    public override void Move(Transform boxTrans)
    {
        moveDistance = 75f;
        boxTrans.Translate(boxTrans.up * -moveDistance);
    }
}