using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BusinessVisual : MonoBehaviour
{
    [SerializeField] private Image businessImage;
    [SerializeField] private Image ramkaImage;
    [SerializeField] private TMP_Text businessName;
    [SerializeField] private TMP_Text businessLevel;
    [SerializeField] private TMP_Text businessPrice;
    [SerializeField] private TMP_Text businessProfit;
    [SerializeField] private TMP_Text buttonActionText;
    [SerializeField] private Button buttonAction;
    [SerializeField] private Color buyColor;
    [SerializeField] private Color improveColor;

    private void OnEnable() => BusinessManager.OnOpenVisual += SetData;
    private void OnDisable() => BusinessManager.OnOpenVisual -= SetData;
    private void SetData(SoBusinessData data, BusinessProgress progress)
    {
        businessImage.sprite = data.Sprite;
        ramkaImage.gameObject.SetActive(!progress.IsOpen);
        businessName.text = data.Name;
        businessLevel.text = progress.IsOpen ? $"{(int)((progress.ImproveFactor - 1f) * 10)}/10" : "";
        businessProfit.text = $"�����: <color=green>{(int)(progress.ImproveFactor * data.Profit)} $/PayDay";
        buttonActionText.text = progress.IsOpen ? "��������" : "������";
        buttonAction.image.color = progress.IsOpen ? improveColor : buyColor;
        if (progress.IsFullImproved)
        {
            businessPrice.text = businessProfit.text;
            businessProfit.text = "";
            buttonActionText.text = "����.�������";
        }
        else
        {
            businessPrice.text = progress.IsOpen ? $"�������� �� <color=green>{(int)(data.Upgrade * progress.ImproveFactor)}$?" : $"������ �� <color=green>{data.Price}$?";
            businessProfit.text = $"�����: <color=green>{progress.ImproveFactor * data.Profit} $/PayDay";
        }
    }
}
