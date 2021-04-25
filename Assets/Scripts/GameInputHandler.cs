using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace CommandPattern
{
    public class GameInputHandler : MonoBehaviour
    {
        public GameObject gameObject;
        public static List<GameCommand> oldCommands = new List<GameCommand>();
        public static bool shouldStartReplay;

        public void Move(InputAction.CallbackContext context)
        {
            GameCommand command = new MoveCommand(gameObject, (Vector3)context.ReadValue<Vector2>());
            oldCommands.Add(command);
            command.Execute();
        }
    }
}