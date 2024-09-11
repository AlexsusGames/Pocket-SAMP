using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinsManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> skins = new List<Sprite>();
    [SerializeField] private Image skinImage;
    private SkinDataChanger skinData = new SkinDataChanger();
    [Space]
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private TMP_Text characterText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text priceText;
    private int index;
    private Wallet wallet = new Wallet();
    [SerializeField] private InfoTabCaller info;

    private void Awake()
    {
        SetData(skinData.GetSkinData().progress[index],index);
    }
    public void NextSkin()
    {
        if (index < skins.Count - 1)
        index++;
        SetData(skinData.GetSkinData().progress[index], index);
    }
    public void BackSkin()
    {
        if(index > 0)
        index--;
        SetData(skinData.GetSkinData().progress[index], index);
    }
    public void BuySkin()
    {
        SkinProgress skinProgress = skinData.GetSkinData().progress[index];
        if (skinProgress.IsOpen == false)
        {
            if (wallet.GetMoney() >= skinProgress.Price)
            {
                wallet.MoneyOperation(-skinProgress.Price);
                skinData.ChangeProgress(index, true);
                SetData(skinData.GetSkinData().progress[index], index);
                info.CallInfoPanel($"Скин {skinProgress.Name} приобретен. Одеть можно дома в шкафу");
            }
            else info.CallInfoPanel("Недостаточно <color=green>$</color>");
        }
    }
    private void SetData(SkinProgress progress, int index)
    {
        if (progress.IsOpen)
        {
            buttonText.text = "Приобретенно";
            priceText.text = string.Empty;
        }
        else
        {
            buttonText.text = "Купить";
            priceText.text = progress.Price.ToString();
        }
        nameText.text = progress.Name;
        characterText.text = progress.Character;
        skinImage.sprite = skins[index];
    }
}
