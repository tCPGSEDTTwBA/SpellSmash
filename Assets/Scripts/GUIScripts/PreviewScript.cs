using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PreviewScript : MonoBehaviour
{
    public List<TextMeshProUGUI> previewTexts;
    public List<TextMeshProUGUI> previewTextScores;

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
            }
        }
    }


}
