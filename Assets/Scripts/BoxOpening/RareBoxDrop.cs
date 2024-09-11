using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RareBoxDrop 
{
    private CarDataLoader carData = new CarDataLoader();
    private SkinDataChanger skinData = new SkinDataChanger();
    private ItemId[] tools = { ItemId.Rake, ItemId.Pick, ItemId.AdditionalHands, ItemId.Chainsaw, ItemId.InstrumentBag };
    private GetItemInfo info = new GetItemInfo();
    private ItemsData itemsData = new ItemsData();
    public static Action<string, int, bool> OnWin;
    private Wallet wallet = new Wallet();
    public SoCarData[] DropCars { set; private get; }
    private AdditionalDropChance chance = new();

    private void DropRareWorkSkin()
    {
        var result = skinData.UnlockRandomSkin(true);
        OnWin?.Invoke(result.name, result.moneyCount, result.value);
        wallet.MoneyOperation(result.moneyCount);
    }
    private void DropBusinessSkin()
    {
        var result = skinData.UnlockRandomSkin(false);
        OnWin?.Invoke(result.name, result.moneyCount, result.value);
        wallet.MoneyOperation(result.moneyCount);
    }
    private void DropRareCar()
    {
        var result = carData.UnlockRandomCar(DropCars);
        OnWin?.Invoke(result.name, result.moneyCount, result.isOpen);
        wallet.MoneyOperation(result.moneyCount);
    }
    private void DropRandomTool()
    {
        int random = UnityEngine.Random.Range(0,tools.Length);
        itemsData.ChangeRes(tools[random],1);
        OnWin?.Invoke(info.GetItemName(tools[random]), 0, true);
    }
    public void DropThingByID(int ID)
    {
        chance.SetDefault();
        switch (ID)
        {
            case 0: DropRareWorkSkin(); break;
            case 1: DropBusinessSkin(); break;
            case 2: DropRareCar(); break;
            case 3: DropRandomTool(); break;
        }
    }
}
