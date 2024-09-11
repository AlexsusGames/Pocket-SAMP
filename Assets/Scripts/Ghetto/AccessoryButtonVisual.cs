using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryButtonVisual : MonoBehaviour
{
    [SerializeField] private Image accessory;
    [SerializeField] private Image rareColor;
    [SerializeField] private TMP_Text rarityText;
    [SerializeField] private Color usual;
    [SerializeField] private Color rare;
    [SerializeField] private Color veryRare;
    [SerializeField] private Color mainDrop;
    [SerializeField] private Sprite unlockSprite;
    public SoAccessory AccessoryData { get; private set; }

    public void SetData(SoAccessory data)
    {
        var rareInfo = GetRarityInfo(data.Rarity);
        accessory.sprite = data.sprite;
        rareColor.color = rareInfo.color;
        rarityText.text = rareInfo.describtion;
        AccessoryData = data;
    }
    private (Color color,string describtion) GetRarityInfo(SlotRarity rarity)
    {
        switch (rarity)
        {
            case SlotRarity.Usual: return (usual,"�������");
            case SlotRarity.Rare: return (rare,"������");
            case SlotRarity.VeryRare: return (veryRare,"��������");
            case SlotRarity.MainDrop: return (mainDrop,"�����������");
            default: return (usual, "�������");
        }
    }
    public void SetUnlockSprite()
    {
        accessory.sprite = unlockSprite;
    }
}
