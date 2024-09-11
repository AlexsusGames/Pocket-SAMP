using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FastFoodManager : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] private int foodCount;
    [SerializeField] private CharacterNeeds needs;
    [SerializeField] private UnityEvent onBuy;
    [SerializeField] private UnityEvent onMoneyAbsence;
    [SerializeField] private UnityEvent onFull;
    [SerializeField] private UnityEvent onNoMoney;
    [SerializeField] private TMP_Text poorEatPrice;
    private Wallet wallet = new Wallet();

    private void Awake()
    {
        HungryCheck();
    }
    public void BuyFood()
    {
        if(foodCount == 100 && wallet.GetMoney() < price && needs.isHungry())
        {
            needs.SetEat(500);
            onNoMoney.Invoke();
        }
        if (wallet.GetMoney() >= price)
        {
            if (needs.SetEat(foodCount))
            {
                wallet.MoneyOperation(-price);
                onBuy.Invoke();
            }
            else onFull.Invoke();
        }
        else onMoneyAbsence.Invoke();
    }
    public void BuyCoffee()
    { 
        if (wallet.GetMoney() >= price)
        {
            if (needs.SetSleep(foodCount))
            {
                wallet.MoneyOperation(-price);
                onBuy.Invoke();
            }
            else onFull.Invoke();
        }
        else onMoneyAbsence.Invoke();
    }
    private void HungryCheck()
    {
        if (foodCount == 100 && wallet.GetMoney() < price && needs.isHungry())
        {
            price = 0;
        }
        poorEatPrice.text = $"{price}$";
    }
}
