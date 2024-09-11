using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfitCalculater 
{
    private Wallet wallet = new Wallet();
    private int profit;

    public void BankOperation(int value)
    {
        wallet.MoneyOperation(value);
    }
    public void ImproveProfit(int value)
    {
        UpdateInfo();
        int result = profit + value;
        PlayerPrefs.SetInt("Profit",result);
    }
    public int GetProfit()
    {
        UpdateInfo ();
        return profit;
    }
    private void UpdateInfo()
    {
        profit = PlayerPrefs.GetInt("Profit");
    }
}
