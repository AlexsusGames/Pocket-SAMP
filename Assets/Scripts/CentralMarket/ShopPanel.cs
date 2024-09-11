using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text resCountText;
    [SerializeField] private TMP_Text actionText;
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text resText;
    [SerializeField] private InfoTabCaller infoTab;
    private ItemsData ResData = new ItemsData();
    private Wallet wallet = new Wallet();
    private PersonalStats stats = new PersonalStats();
    private GetItemInfo itemInfo = new GetItemInfo();
    private ItemId resId;
    private int ResCount;
    private int price;
    private bool isBuy;
    private string action;

    private void OnEnable()
    {
        SetStandartCount();
        ResData.LoadData();
    }
    public void SetSettings(ItemId res,int price,bool isBuy)
    {
        resId = res;
        this.price = price;
        this.isBuy = isBuy;
        action = isBuy ? "Купить" : "Продать";
        SetStandartCount();
        UpdateResCount();
    }
    public void ChangeRes()
    {
        int result = ResCount * price;
        if (!isBuy && ResCount > 0)
        {
            if(ResData.GetRes(resId) >= ResCount)
            {
                stats.ChangeStats(ResCount, stats.ItemsSoldKey);
                ResData.ChangeRes(resId, -ResCount);
                wallet.MoneyOperation(result);
                infoTab.CallInfoPanel($"Вы продали <color=green>{ResCount}</color> '{itemInfo.GetItemName(resId)}' за <color=green>{result}$</color>");
                SetStandartCount();
                UpdateResCount();
            }
            else infoTab.CallInfoPanel($"Не хватает <color=green>'{itemInfo.GetItemName(resId)}'</color> на балансе");
        }
        else if (isBuy && ResCount > 0)
        {
            if(wallet.GetMoney() >= result)
            {
                wallet.MoneyOperation(-result);
                ResData.ChangeRes(resId, ResCount);
                infoTab.CallInfoPanel($"Вы купили <color=green>{ResCount}</color> '{itemInfo.GetItemName(resId)}' за <color=green>{result}$</color>");
                SetStandartCount();
            }
            else infoTab.CallInfoPanel($"Не хватает <color=green>$</color> для покупки <color=green>{ResCount}</color> '{itemInfo.GetItemName(resId)}'");
        }
    }
    public void ChangeResCount(int value)
    {
        ResCount += value;
        UpdateInfo();
    }
    private void UpdateInfo()
    {
        resCountText.text = ResCount.ToString();
        actionText.text = action;
        moneyText.text = $"{wallet.GetMoney()}$";
    }
    public void SetStandartCount()
    {
        ResCount = 0;
        UpdateInfo();
    }
    public void SetInfinity()
    {
        if (!isBuy)
        {
            ResCount = ResData.GetRes(resId);
            UpdateInfo();
        }
        else if (isBuy)
        {
            ResCount = wallet.GetMoney() / price;
            UpdateInfo();   
        }
    }
    private void UpdateResCount()
    {
        if (!isBuy)
            resText.text = $"{ResData.GetRes(resId)} шт.";
        else resText.text = "";
    }
}
