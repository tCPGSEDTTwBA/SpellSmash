using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Vector3 origin;
    public int sizeX = 11;
    public int sizeY = 23;
    public GameObject boardSprite;

    // Start is called before the first frame update
    void Start()
    {
        createBoard();
    }

    void createBoard()
    {
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                GameObject newPiece = Instantiate(boardSprite, new Vector3(origin.x + x, origin.y + y, origin.z + 0), Quaternion.identity, transform);
            }
        }
    }

}