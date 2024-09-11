using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBoxData
{
    public int dropId;
    public ItemId itemId;
    public int count;
    public SlotRarity rarity;
    private RareBoxDrop mainDrop = new RareBoxDrop();
    private ItemsData data = new ItemsData();
    private DropCaclulater caclulater = new DropCaclulater();
    public static Action<string, int> OnWin;
    private GetItemInfo info = new GetItemInfo();
    private SoCarData[] carPack;
    private ItemId boxId;
    private SoBoxDrop dropData;

    public SlotBoxData(int dropId, SoCarData[] carPack, ItemId BoxId, SoBoxDrop drop)
    {
        this.dropId = dropId;
        this.carPack = carPack;
        boxId = BoxId;
        dropData = drop;
        SetData();
    }

    private void SetData()
    {
        rarity = caclulater.GetRarity(boxId);
        itemId = caclulater.GetItemId(rarity,dropData);
        count = caclulater.GetItemCount(rarity);
        mainDrop.DropCars = carPack;
    }
    public void GiveReward()
    {
        if (rarity == SlotRarity.MainDrop) mainDrop.DropThingByID(dropId);
        else
        {
            data.ChangeRes(itemId, count);
            OnWin?.Invoke(info.GetItemName(itemId), count);
        }
    }
}
public enum SlotRarity
{
    Usual = 0,
    Rare = 1,
    VeryRare = 2,
    MainDrop = 3
}
