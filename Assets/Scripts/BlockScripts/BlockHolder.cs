using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlockHolder : MonoBehaviour
{
    private Letter letter;
    [SerializeField]
    private GameObject previewUI;
    [SerializeField]
    private TextMeshProUGUI previewText;
    [SerializeField]
    private TextMeshProUGUI previewScore;
    [SerializeField]
    private Image backgroundImage;

    private void Update()
    {
        if(HasLetter()) {
            UpdatePreview();
        }
    }

    private void UpdatePreview()
    {
        if(HasLetter()) {
            previewText.text = letter.Value.ToString();
            previewScore.text = letter.Score.ToString();
            if(letter.isMultiplier) {
                backgroundImage.color = new Color32(208, 177, 62, 255);
            }
        }
    }

    public void HoldLetter(Letter letter)
    {
        this.letter = letter;
        previewUI.gameObject.SetActive(true);
    }

    public Letter UseLetter()
    {
        if(HasLetter()) {
            previewUI.gameObject.SetActive(false);
            return letter;
        }
        return null;
    }

    public bool HasLetter()
    {
        return (previewUI.activeSelf && letter != null);
    }

}
