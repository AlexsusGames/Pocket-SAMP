using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;

public class SlotMachineController : MonoBehaviour
{
    [SerializeField] private CasinoSlotsVisual visual;
    [SerializeField] private InfoTabCaller infoTab;
    [SerializeField] private AudioPlayer turnSound;
    [SerializeField] private AudioPlayer winSound;
    private List<int> slots;

    private SlotMachineModel model = new();
    private Wallet wallet = new();
    private PersonalStats stats = new();

    private void Awake()
    {
        visual.Init(model);
        visual.OnSlotTurned += GiveRewards;
    }

    public void TurnSlot()
    {
        if (wallet.GetMoney() >= model.Bet)
        {
            wallet.MoneyOperation(-model.Bet);
            slots = model.GetCombination();
            StartCoroutine(visual.TurnSlots(slots));
            turnSound.Play();
        }
        else infoTab.CallInfoPanel("Не хватает денег на ставку!");
    }
    private void GiveRewards()
    {
        int result = model.CheckCombination(slots);
        if (result != 0)
        {
            wallet.MoneyOperation(result);
            stats.ChangeStats(result, stats.CasinoWinKey);
            infoTab.CallInfoPanel($"Вы выиграли <color=green>{result}$</color>. Поздравляем!");
        }
        else
        {
            stats.ChangeStats(model.Bet, stats.CasinoLostKey);
            infoTab.CallInfoPanel($"Вы проиграли <color=green>{model.Bet}$</color>.");
        }  
        winSound.Play();
    }
}
