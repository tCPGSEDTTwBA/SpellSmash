using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    private Letter letter;
    public TextMeshProUGUI text;
    public TextMeshProUGUI scoreText;
    public Image backGroundImage;
    public ParticleSystem particles;
    private string value;
    private bool landed = false;
    private bool sfxPlayed = false;
    private bool isMultiplier = false;

    //The lower the update interval, the faster command are issued to the active block
    public float updateInterval = 0.25f;

    private void Awake()
    {
        letter = LetterQueue.GetNextLetter();
        isMultiplier = letter.isMultiplier;
        if(isMultiplier) {
            backGroundImage.gameObject.SetActive(true);
            particles.gameObject.SetActive(true);

            backGroundImage.color = new Color32(208, 177, 62, 255);
        }

        value = letter.Value.ToString();
        scoreText.text = letter.Score.ToString();
        text.text = value;
    }

    public Letter GetLetter()
    {
        return this.letter;
    }

    private void Start()
    {
        InvokeRepeating("MoveDown", 0.25f, updateInterval);
    }

    /*
     * Using array for O(1) speed
     * Index 0: UP
     * Index 1: DOWN
     * Index 2: LEFT
     * Index 3: RIGHT
     */
    private bool[] freeDirections = new bool[] { true, true ,true ,true };

    private void MoveDown()
    {
        if(freeDirections[1])
        {
            new MoveCommand(this.GetComponent<Rigidbody2D>(), Vector3.down).Execute();
        } else {
            landed = true;
        }
    }

    public bool[] GetFreeDirections()
    {
        return freeDirections;
    }

    public string GetValue()
    {
        return this.value;
    }

    private void OnDestroy()
    {
        this.gameObject.layer = 2;
    }

    public void Update()
    {
        CheckCollision();
        if (!sfxPlayed && landed) {
            FindObjectOfType<AudioManager>().Play("BlockImpact");
            sfxPlayed = true;
        }
    }

    public void CheckCollision()
    {
        RaycastHit2D[] raycasts = raycasts = new RaycastHit2D[] {
            Physics2D.Raycast(transform.position, Vector2.up, 0),
            Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity),
            Physics2D.Raycast(transform.position, Vector2.left, Mathf.Infinity),
            Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity)
        };
        //For each ray, do this
        for (int x = 0; x < raycasts.Length; x++) {
            //If ray has hit something
            if(raycasts[x].collider != null) {
                //Get the distance from the block to the point of impact
                float distance = Vector2.Distance(raycasts[x].point, transform.position);
                /*If the distance is less than or equal to 0.5 (the width of the block) then the block is touching a collider
                If the distance is more than 0.5 then the block is not touching anything and should be free to move in that direction*/
                if (distance <= 0.5f) {
                    freeDirections[x] = false;
                } else if(distance > 0.5f) {
                    freeDirections[x] = true;
                }
            }
        }
    }
}
