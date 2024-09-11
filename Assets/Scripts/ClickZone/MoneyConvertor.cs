using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyConvertor : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text textAzToConvert;
    [SerializeField] private TMP_Text textMoneyToConvert;
    private Wallet wallet = new Wallet();
    private int count = 0;
    private const int MoneyForAz = 500;

    private void OnEnable()
    {
        UpdateInfo();
        AmountChanger(0);
        slider.onValueChanged.AddListener(AmountChanger);
    }
    private void AmountChanger(float amount)
    {
        int amountInInt = Convert.ToInt32(amount);
        textAzToConvert.text = amountInInt.ToString();
        textMoneyToConvert.text = (amountInInt * MoneyForAz).ToString();
        count = amountInInt;
    }
    private void UpdateInfo()
    {
        int az = wallet.GetDonate();
        slider.value = 0;
        slider.maxValue = az;
    }
    public void ConvertMoney()
    {
        wallet.MoneyOperation(count * MoneyForAz);
        wallet.DonateOperation(-count);
        UpdateInfo();
    }
}
