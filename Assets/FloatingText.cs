using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float destroyTime = 3f;
    public TextMeshProUGUI text;


    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }

}
