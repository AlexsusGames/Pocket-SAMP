using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyPrinter : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text respectsText;
    [SerializeField] private TMP_Text donateText;
    private Wallet wallet = new Wallet();

    private void OnEnable()
    {
        UpdateInfo();
        Wallet.OnMoneyChanged += UpdateInfo;
    }
    private void OnDisable() => Wallet.OnMoneyChanged -= UpdateInfo;

    public void UpdateInfo()
    {
        moneyText.text = wallet.GetMoney().ToString();
        respectsText.text = wallet.GetRespects().ToString();
        if(donateText != null) 
        donateText.text = wallet.GetDonate().ToString();
    }
}
