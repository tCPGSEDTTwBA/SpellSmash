using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class UserInputHandler : MonoBehaviour
{
    public static List<GameCommand> oldCommands = new List<GameCommand>();
    public static bool shouldStartReplay;
    private GameObject activeObject;

    [SerializeField]
    private BlockHolder blockHolder;

    public void Move(InputAction.CallbackContext context)
    {
        if (activeObject != null) {
            Vector2Int possibleMove = Vector2Int.RoundToInt(context.ReadValue<Vector2>());
            //If the possible move is a free direction for the block, move that way
            if(DirectionDictionary.HasKey(possibleMove)) {
                //Disgusting but takes Vector3 -> String direction -> integer index
                if (activeObject.GetComponent<Block>().GetFreeDirections()[DirectionDictionary.GetIndex(DirectionDictionary.GetDirection(possibleMove))]) {
                    GameCommand command = new MoveCommand(activeObject.GetComponent<Rigidbody2D>(), possibleMove);
                    oldCommands.Add(command);
                    command.Execute();
                }
            }
        }
    }

    public void HoldLetter(InputAction.CallbackContext context)
    {
        if (context.performed) {
            if(blockHolder.HasLetter()) {
                Letter letter = blockHolder.UseLetter();
                LetterQueue.SkipQueue(letter);
            } else if(activeObject != null) {
                blockHolder.HoldLetter(activeObject.GetComponent<Block>().GetLetter());
                Destroy(activeObject);
            }
        }
    }

    public void SetActiveObject(GameObject activeObject)
    {
        this.activeObject = activeObject;
    }

    public void ClearActiveObject()
    {
        if (activeObject != null) {
            activeObject = null;
        }
    }
}