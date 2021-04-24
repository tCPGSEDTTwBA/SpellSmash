using CommandPattern;
using UnityEngine;

public class MoveRight : GameCommand
{
    public override void Execute(Transform boxTrans, GameCommand command)
    {
        Move(boxTrans);

        GameInputHandler.oldCommands.Add(command);
    }

    public override void Move(Transform boxTrans)
    {
        boxTrans.Translate(boxTrans.right * moveDistance);
    }

}
