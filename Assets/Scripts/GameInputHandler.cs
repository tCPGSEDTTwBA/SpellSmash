using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CommandPattern
{
    public class GameInputHandler : MonoBehaviour
    {
        public Transform boxTrans;
        private GameCommand buttonA, buttonD, buttonS, buttonLeftArrow, buttonRightArrow, buttonDownArrow;
        public static List<GameCommand> oldCommands = new List<GameCommand>();
        public static bool shouldStartReplay;


        void Start()
        {
            buttonA = new MoveLeft();
            buttonLeftArrow = new MoveLeft();

            buttonS = new MoveDown();
            buttonDownArrow = new MoveDown();

            buttonD = new MoveRight();
            buttonRightArrow = new MoveRight();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                buttonA.Execute(boxTrans, buttonA);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                buttonLeftArrow.Execute(boxTrans, buttonLeftArrow);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                buttonD.Execute(boxTrans, buttonD);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                buttonRightArrow.Execute(boxTrans, buttonRightArrow);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                buttonS.Execute(boxTrans, buttonS);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                buttonDownArrow.Execute(boxTrans, buttonDownArrow);
            }
        }
    }
}