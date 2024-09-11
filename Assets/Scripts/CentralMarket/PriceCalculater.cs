using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PriceCalculater
{
    private SoCraftData[] soCrafts => Resources.LoadAll<SoCraftData>("Items");
    private SoOffersData[] soOffers => Resources.LoadAll<SoOffersData>("Offers");
    private List<int> values = new List<int>();
    private ItemId[] itemsCraft = {ItemId.Cloth, ItemId.EliteCloth, ItemId.Lubricant, ItemId.Cooling, ItemId.Matterial, ItemId.Bottle, ItemId.DistilledWater,
    ItemId.Rake, ItemId.Chainsaw, ItemId.Pick, ItemId.InstrumentBag, ItemId.AdditionalHands,ItemId.KppImprove,ItemId.KolenvalImprove,ItemId.NagnetatelImprove,
    ItemId.TurbocompressorImprove, ItemId.KppSport, ItemId.KolenvalSport,ItemId.NagnetatelSport,ItemId.TurbocompressorSport,ItemId.KppSportPlus,ItemId.KolenvalSportPlus,
    ItemId.NagnetatelSportPlus,ItemId.TurbocompressorSportPlus};
    private ItemId[] itemsOffer = { ItemId.Videocard };
    public int GetPrice(ItemId res)
    {
        switch (res)
        {
            case ItemId.Linen: return 4;
            case ItemId.Cotton: return 3;
            case ItemId.OldCloth: return 31;
            case ItemId.Wood: return 11;
            case ItemId.BestWood: return 52;
            case ItemId.Stone: return 26;
            case ItemId.Metal: return 28;
            case ItemId.Bronze: return 125;
            case ItemId.Silver: return 52;
            case ItemId.Gold: return 538;
            case ItemId.Detail1: return 72;
            case ItemId.Detail2: return 74;
            case ItemId.StageDetail: return 520;
            case ItemId.Wrench: return 116;
            case ItemId.Wiring: return 121;
            case ItemId.Aluminum: return 1180;
            case ItemId.BoxSimpleCar: return 1000;
            case ItemId.BoxWithBonus: return 1500;
            case ItemId.BoxSuperCar: return 2000;
            case ItemId.BoxLuxury: return 2500;
            case ItemId.RandonCarBox: return 10000;
            case ItemId.ToolBox: return 1000;
            case ItemId.BestCarsBox: return 3000;
            default: return FindPrice(res); 
        }
    }
    private int FindPrice(ItemId id)
    {
        for (int i = 0; i < itemsCraft.Length; i++)
        {
            if (id == itemsCraft[i]) return Calculating(id);
        }
        for (int i = 0; i < itemsOffer.Length; i++)
        {
            if (id == itemsOffer[i]) return GetOfferPrice(id);
        }
        return 0;
    }
    private int Calculating(ItemId id)
    {
        values.Clear();
        for (int i = 0; i < soCrafts.Length; i++)
        {
            if (soCrafts[i].CraftItem == id)
            {
                for (int j = 0; j < soCrafts[i].Resources.Count; j++)
                {
                    int result = GetPrice(soCrafts[i].Resources[j]) * soCrafts[i].ResourcesCount[j];
                    values.Add(result);
                }
                int sum = values.Sum();
                float price = (float)sum * (100 / soCrafts[i].CraftChance);
                return (int)price;
            }
        }
        return 0;
    }
    private int GetOfferPrice(ItemId id)
    {
        for (int i = 0; i < soOffers.Length; i++)
        {
            if (soOffers[i].ItemId == id)
            {
                int value1 = GetPrice(soOffers[i].itemsForOffer[0]);
                int value2 = GetPrice(soOffers[i].itemsForOffer[1]);
                int result = (value1 + value2) * 8 / 10;
                return result;
            }
        }
        return 0;
    }
}
