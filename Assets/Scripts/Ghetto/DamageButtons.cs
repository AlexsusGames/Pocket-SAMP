using System;
using System.Collections;
using System.Collections.Generic;
using System.Media;
using TMPro;
using UnityEngine;

public class DamageButtons : MonoBehaviour
{
    [SerializeField] private TMP_Text[] countTexts;
    [SerializeField] private int[] prices;
    [SerializeField] private InfoTabCaller info;
    [SerializeField] private CharacterNeeds needs;
    [SerializeField] private AudioPlayer[] sounds;
    private int[] standartCounts = { 1, 1, 1 };
    private Wallet wallet = new();
    private GhettoState state = new();
    private GhettoStatsData stats = new();
    public event Action OnEndHealth;


    public void ChangeCountUp(int index)
    {
        standartCounts[index] += 1;
        countTexts[index].text = (prices[index] * standartCounts[index]).ToString();
    }
    public void ChangeCountDown(int index)
    {
        standartCounts[index] -= 1;
        if (standartCounts[index] < 1) standartCounts[index] = 1;
        countTexts[index].text = (prices[index] * standartCounts[index]).ToString();
    }
    public void GetDamage(int index)
    {
        var stateData = state.GetState();
        if(stateData.CurrentHealth > 0)
        {
            int damage = stats.GetDamage();
            string action;
            int count = standartCounts[index];
            switch (index)
            {
                default:
                    {
                        action = "Вы ударили битой и нанесли:";
                        int totalDamage = damage / 2 * standartCounts[index];
                        int totalPrice = prices[index] * count * 10;
                        if (needs.data.GetSleepNeed() >= totalPrice)
                        {
                            needs.data.SetSleepStat(-totalPrice);
                            stateData.CurrentHealth -= totalDamage;
                            stateData.ChatMessages.Add($"{action} <color=green>{totalDamage}</color> урона.");
                            sounds[index].Play();
                        }
                        else info.CallInfoPanel("Недостаточно <color=red>энергии</color> для совершения действия!");
                    }
                    break;
                case 1:
                    {
                        action = "Вы выстрелили из пистолета и нанесли:";
                        int totalDamage = damage * standartCounts[index];
                        int totalPrice = prices[index] * count;
                        if (wallet.GetMoney() >= totalPrice)
                        {
                            wallet.MoneyOperation(-totalPrice);
                            stateData.CurrentHealth -= totalDamage;
                            stateData.ChatMessages.Add($"{action} <color=green>{totalDamage}</color> урона.");
                            sounds[index].Play();
                        }
                        else info.CallInfoPanel("Недостаточно <color=green>денег</color> для совершения действия!");
                    }
                    break;
                case 2:
                    {
                        action = "Вы выстрелили из дробовика и нанесли:";
                        int totalDamage = damage * 10 * standartCounts[index];
                        int totalPrice = prices[index] * count;
                        if (wallet.GetDonate() >= totalPrice)
                        {
                            wallet.DonateOperation(-totalPrice);
                            stateData.CurrentHealth -= totalDamage;
                            stateData.ChatMessages.Add($"{action} <color=green>{totalDamage}</color> урона.");
                            sounds[index].Play();
                        }
                        else info.CallInfoPanel("Недостаточно <color=yellow>PS-coins</color> для совершения действия!");
                    }
                    break;
            }
            if (stateData.CurrentHealth <= 0)
            {
                stateData.CurrentHealth = 0;
                Invoke(nameof(FinishFight), 1);
            }
            state.SaveState();
            state.UpdateView();
        }
    }
    private void FinishFight()
    {
        OnEndHealth?.Invoke();
    }

}
