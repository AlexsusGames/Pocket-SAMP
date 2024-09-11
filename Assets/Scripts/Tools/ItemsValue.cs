using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsValue 
{
    public ItemId[] UsualResourse { get; private set; } = { ItemId.Cotton, ItemId.Linen, ItemId.Wood, ItemId.Stone, ItemId.Silver, ItemId.Metal };
    public ItemId[] RareResourse { get; private set; } = { ItemId.Detail1, ItemId.Detail2, ItemId.Wiring, ItemId.Wrench };
    public ItemId[] ExpensiveResourse { get; private set; } = { ItemId.OldCloth, ItemId.BestWood, ItemId.Bronze, ItemId.Gold, ItemId.StageDetail, ItemId.Aluminum };
    public ItemId[] CraftItems { get; private set; } = { ItemId.Cooling, ItemId.DistilledWater, ItemId.Bottle, ItemId.Matterial, ItemId.Lubricant };
    public ItemId[] TuningItems { get; private set; } = { ItemId.KolenvalImprove, ItemId.KppImprove, ItemId.NagnetatelImprove, ItemId.TurbocompressorImprove };
    public ItemId[] RareAndUsualResources { get; private set; } = { ItemId.Cotton, ItemId.Linen, ItemId.Wood, ItemId.Stone, ItemId.Silver, ItemId.Metal, ItemId.Detail1, ItemId.Detail2, ItemId.Wiring, ItemId.Wrench };

    public ItemId GetItem(ItemId[] items)
    {
        return items[Random.Range(0, items.Length)];
    }
}
