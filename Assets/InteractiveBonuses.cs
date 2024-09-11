using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveBonuses 
{
    private ItemsData data = new();
    private Wallet wallet = new();

    private SoWork work;
    private ClickFactor factor;
    private CharacterNeeds needs;

    public InteractiveBonuses(SoWork soWork, CharacterNeeds needs)
    {
        work = soWork;
        factor = new(work.WorkId);
        this.needs = needs;
    }

    public (UnityAction Action, int ActionId, ItemId ItemId) GetBonus()
    {
        int random = Random.Range(0, 20);
        UnityAction action;
        switch (random)
        {
            case 0:
                {
                    action = GetBonusFood;
                    return (action, 2, ItemId.None);
                }
            case 1:
                {
                    action = GetPsBonus;
                    return (action, 3, ItemId.None);
                }
            default:
                {
                    int actionId = work.IsCanEmploy ? 1 : 0;
                    ItemId item = GetRes();
                    action = work.IsCanEmploy ? GetBonusMoney : () => data.ChangeRes(item, factor.Factor);
                    return (action, actionId, item);
                }
        }
    }

    private ItemId GetRes()
    {
        var item = work.Rareitem;
        int random = Random.Range(1, 101);
        if (random > 99) return ItemId.Gold;
        if (random > 90) return ItemId.Silver;
        return item;
    }
    private void GetBonusMoney()
    {
        int result = Random.Range(work.MinPayment, work.MaxPayment) * Random.Range(1, 5);
        wallet.MoneyOperation(result);
    }
    private void GetBonusFood()
    {
        needs.SetSleep(100);
    }
    private void GetPsBonus()
    {
        wallet.DonateOperation(1);
    }
}
