using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PawnShopSellMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text offerText;
    [SerializeField] private Slider countSlider;
    [SerializeField] private TMP_Text endValue;
    [SerializeField] private InfoTabCaller info;
    private ItemsData itemData = new ItemsData();
    private PriceCalculater priceCalculater = new PriceCalculater();
    private Wallet wallet = new Wallet();
    private GetItemInfo itemInfo = new GetItemInfo();
    private PersonalStats stats = new PersonalStats();
    private int count;
    private int price;
    private ItemId itemId;
    public static Action OnSell;
    private void Awake()
    {
        countSlider.onValueChanged.AddListener(SetCount);
    }
    public void SetData(ItemId Id)
    {
        itemId = Id;
        SetSettings();
        countSlider.value = 0;
        countSlider.maxValue = itemData.GetRes(itemId);
        endValue.text = countSlider.maxValue.ToString();
    }
    public void SetCount(float value)
    {
        count = (int)value;
        UpdateInfo();
    }
    private void UpdateInfo()
    {
        int price = this.price * count;
        offerText.text = $"Продать <color=green>{count}</color> шт. за <color=green>{price}$</color>?";
    }
    private void SetSettings()
    {
        itemName.text = itemInfo.GetItemName(itemId);
        price = priceCalculater.GetPrice(itemId);
        count = 0;
        UpdateInfo();
    }
    public void Sell()
    {
        stats.ChangeStats(count, stats.ItemsSoldKey);
        itemData.ChangeRes(itemId, -count);
        int result = price * count;
        stats.ChangeStats(result, stats.MoneyEarnedKey);
        wallet.MoneyOperation(result);
        gameObject.SetActive(false);
        OnSell?.Invoke();
        info.CallInfoPanel($"Вы успешно продали <color=green>{count}</color> шт. '{itemInfo.GetItemName(itemId)}' за <color=green>{result}$</color>!");
    }
}
