using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusinessManager : MonoBehaviour
{
    [SerializeField] private Button buttonBuy;
    private SoBusinessData[] soBusinessData => Resources.LoadAll<SoBusinessData>("Business");
    public static Action<SoBusinessData,BusinessProgress> OnOpenVisual;
    private BusinessDataChanger data = new BusinessDataChanger();
    private Wallet wallet = new Wallet();
    private ProfitCalculater bank = new ProfitCalculater();
    private int index;

    public void SetData(int index)
    {
        OnOpenVisual?.Invoke(FindBusinessByIndex(index),data.GetProgress(index));
        this.index = index;
        buttonBuy.onClick.RemoveAllListeners();
        buttonBuy.onClick.AddListener(data.IsOpened(index) ? ImproveBusiness : BuyBusiness);
    }
    public void BuyBusiness()
    {
        SoBusinessData business = FindBusinessByIndex(index);
        if (!data.IsOpened(index))
        {
            if (wallet.GetMoney() >= business.Price)
            {
                data.OpenBusiness(index);
                wallet.MoneyOperation(-business.Price);
                bank.ImproveProfit(business.Profit);
                OnOpenVisual.Invoke(business,data.GetProgress(index));
                SetData(index);
            }
        }
    }
    public void ImproveBusiness()
    {
        SoBusinessData business = FindBusinessByIndex(index);
        if (data.IsOpened(index) && data.GetImpoveFactor(index) < 2.0f)
        {
            int priceForUpdate = (int)(business.Upgrade * data.GetImpoveFactor(index));
            int profitForUpdate = (int)(business.Profit * data.GetImpoveFactor(index));
            if (wallet.GetMoney() >= priceForUpdate)
            {
                data.ImproveBusinessLevel(index);
                wallet.MoneyOperation(-priceForUpdate);
                bank.ImproveProfit((int)(business.Profit * data.GetImpoveFactor(index)) - profitForUpdate);
                OnOpenVisual.Invoke(business,data.GetProgress(index));
            }
        }
    }
    private SoBusinessData FindBusinessByIndex(int index)
    {
        for (int i = 0; i < soBusinessData.Length; i++)
        {
            if (soBusinessData[i].Index == index) return soBusinessData[i];
        }
        return null;
    }
}
