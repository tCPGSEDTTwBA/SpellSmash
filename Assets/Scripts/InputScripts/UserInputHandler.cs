using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class UserInputHandler : MonoBehaviour
{
    public static List<GameCommand> oldCommands = new List<GameCommand>();
    public static bool shouldStartReplay;
    private GameObject activeObject;

    public void Move(InputAction.CallbackContext context)
    {
        if (activeObject != null) {
            GameCommand command = new MoveCommand(activeObject, (Vector3)context.ReadValue<Vector2>());
            oldCommands.Add(command);
        }
    }
    public void setActiveObject(GameObject activeObject)
    {
        this.activeObject = activeObject;
    }

    public void clearActiveObject()
    {
        if (activeObject != null) {
            activeObject = null;
        }
    }

}