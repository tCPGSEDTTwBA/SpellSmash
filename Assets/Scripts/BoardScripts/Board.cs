using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    GameObject[,] board = new GameObject[10, 22];

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("I am running");

        createBoard();

    }

    // Update is called once per frame
    void Update()
    {
        updateBoard();
    }

    void createBoard()
    {
        for (int x = 0; x < 10; x++){
            for (int y = 0; y < 22; y++){
                board[x, y] = null;
            }
        }
        Debug.Log("Board created");
    }

    void updateBoard()
    {
        for (int x = 0; x < 10; x++){
            for (int y = 0; y < 22; y++){
                if (board[x, y] != null){
                    GameObject block = board[x, y];
                    //block.displayBlock();
                }
            }
        }
    }

}