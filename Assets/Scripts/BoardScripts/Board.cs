using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int sizeX = 11;
    public int sizeY = 23;
    public GameObject boardSprite;
    //Traditional tetris board is 10 by 22
    private GameObject[,] board;

    private void Awake()
    {
        board = new GameObject[sizeX, sizeY];
    }

    // Start is called before the first frame update
    void Start()
    {
        createBoard();
    }

    // Update is called once per frame
    void Update()
    {
        //updateBoard();
    }

    void createBoard()
    {
        for (int x = 0; x < board.GetLength(0); x++)
        {
            for (int y = 0; y < board.GetLength(1); y++)
            {
                GameObject newPiece = Instantiate(boardSprite, new Vector3Int(x, y, 0), Quaternion.identity, transform);
                board[x, y] = newPiece;
            }
        }
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