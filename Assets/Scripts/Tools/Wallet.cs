using System;
using UnityEngine;

public class Wallet 
{
    private int money;
    private int respects;
    private int donate;
    public static Action OnMoneyChanged;

    public int GetMoney()
    {
        UpdateInfo();
        return money;
    }
    public int GetRespects()
    {
        UpdateInfo();
        return respects;
    }
    public int GetDonate()
    {
        UpdateInfo();
        return donate;
    }
    public void RespectsOperation(int value)
    {
        UpdateInfo();
        int result = respects + value;
        PlayerPrefs.SetInt("Respects", result);
        OnMoneyChanged?.Invoke();
    }
    public void MoneyOperation(int value)
    {
        UpdateInfo();
        int result = money + value;
        PlayerPrefs.SetInt("Money", result);
        OnMoneyChanged?.Invoke();
    }
    public void DonateOperation(int value)
    {
        UpdateInfo();
        int result = donate + value;
        PlayerPrefs.SetInt("Donate", result);
        OnMoneyChanged?.Invoke();
    }
    private void UpdateInfo()
    {
        money = PlayerPrefs.GetInt("Money");
        respects = PlayerPrefs.GetInt("Respects");
        donate = PlayerPrefs.GetInt("Donate");
    }
}
