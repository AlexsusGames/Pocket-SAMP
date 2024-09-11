using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotVisual : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text itemType;
    [SerializeField] private Color[] rareColors;
    [SerializeField] private string[] types;
    [SerializeField] private Image rareColor;

    public void SetData(SlotBoxData slot,Sprite itemSprite)
    {
        itemImage.sprite = itemSprite;
        rareColor.color = rareColors[(int)slot.rarity];
        itemType.text = types[(int)slot.rarity];
    }
}
