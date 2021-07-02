using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PreviewScript : MonoBehaviour
{
    public List<TextMeshProUGUI> previewTexts;
    public List<TextMeshProUGUI> previewTextScores;
    public List<Image> backgroundImages;

    private void FixedUpdate()
    {
        RefreshText();
    }

    public void RefreshText()
    {
        var letterQueue = LetterQueue.GetLetterQueue();
        for (int x = 0; x < previewTexts.Count && x < letterQueue.Count; x++)
        {
            if (previewTexts[x] != null)
            {
                previewTexts[x].text = letterQueue[x].Value.ToString();
                previewTextScores[x].text = letterQueue[x].Score.ToString();
                if(letterQueue[x].isMultiplier) {
                    backgroundImages[x].color = new Color32(208, 177, 62, 255);
                } else {
                    backgroundImages[x].color = new Color32(124, 139, 154, 255);
                }
            }
        }
    }


}
