using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VideocardVisual : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Image image;
    [SerializeField] private Color color;
    [SerializeField] private Image coolingProgress;
    [SerializeField] private Image improveImage;

    public void SetData(Videocard videocard)
    {
        image.color = videocard.Level > 0 ? Color.white : color;
        levelText.text = videocard.Level > 0 ? videocard.Level.ToString() : "";
        coolingProgress.fillAmount = videocard.CoolingBar;
        improveImage.gameObject.SetActive(videocard.Level < 10 && videocard.Level != 0);
        Button button = GetComponent<Button>();
        button.interactable = videocard.Level > 0;
    }
}
