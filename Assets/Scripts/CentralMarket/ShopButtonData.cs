using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonData : MonoBehaviour
{
    [SerializeField]private TMP_Text priceText;
    private PriceCalculater priceCalculater = new PriceCalculater();
    private int price;
    public bool isBuy;
    [SerializeField] private ShopPanel panel;
    private ItemId resName;
    private CharactersBonuses bonus = new CharactersBonuses();
    private SelectableObject selectableObject;

    public void SetData(ItemId name)
    {
        selectableObject = GetComponent<SelectableObject>();
        CalculatePrice(priceCalculater.GetPrice(name));
        string result = $"{price}<color=green>$";
        priceText.text = result;
        resName = name;
    }
    private void CalculatePrice(int result)
    {
        if (!isBuy)
            price = bonus.CalculateSellSale(result);
        else price = bonus.CalculateBuySale(result) * 2;
    }
    public void CallPanel()
    {
        panel.SetSettings(resName, price, isBuy);
        selectableObject.Select();
    }
}
