using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class DropdownManager : MonoBehaviour
{
    public List<string> values;
    public GameObject[] objects;
    public int DEFAULT_VALUE;
    public TMP_Dropdown dropdown;
    private bool objectsEnabled = true;

    private void Awake()
    {
        dropdown.AddOptions(values);
        dropdown.value = PlayerPrefs.GetInt("gamemode", DEFAULT_VALUE);
    }

    public void OnValueChange()
    {
        objectsEnabled = !objectsEnabled;
        Array.ForEach(objects, o => o.SetActive(objectsEnabled));
        PlayerPrefs.SetInt("gamemode", dropdown.value);
    }
}
