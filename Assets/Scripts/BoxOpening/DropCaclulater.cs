using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCaclulater 
{
    private AdditionalDropChance chance = new();
    public SlotRarity GetRarity(ItemId box)
    {
        int random = Random.Range(0, 101);
        int additionalChance = box == ItemId.BestCarsBox ? 0 : chance.GetAdditionalChance();
        if (box == ItemId.RandonCarBox) random = 100;
        if (random > (99 - additionalChance)) return SlotRarity.MainDrop;
        else if (random >= 90) return SlotRarity.VeryRare;
        else if (random >= 70) return SlotRarity.Rare;
        else return SlotRarity.Usual;
    }
    public ItemId GetItemId(SlotRarity rarity,SoBoxDrop drop)
    {
        switch (rarity)
        {
            case SlotRarity.Usual: return drop.GetUsualItem;
            case SlotRarity.Rare: return drop.GetRareItem;
            case SlotRarity.VeryRare: return drop.GetVeryRareItem;
            default: return ItemId.None;
        }
    }
    public int GetItemCount(SlotRarity item)
    {
        if(item == SlotRarity.MainDrop) return 0;   
        if (item == SlotRarity.Usual) return Random.Range(1, 100);
        else if(item == SlotRarity.Rare) return Random.Range(1, 5);
        else return 1;
    }
}
