using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsData 
{
    private List<int> items = new List<int>();

    public List<int> GetItemList()
    {
        LoadData();
        return items;
    }
    public void SaveData(List<int> res)
    {
        int enumCount = System.Enum.GetValues(typeof(ItemId)).Length;
        for (int i = 0; i < enumCount; i++)
        {
            PlayerPrefs.SetInt($"Res{i}", res[i]);
        }
    }
    public void SaveItem(int index, int count)
    {
        PlayerPrefs.SetInt($"Res{index}", count);
    }
    public void ChangeRes(ItemId name,int value)
    {
        if((int)name >= 0)
        {
            int item = LoadItem((int)name);
            item += value;
            SaveItem((int)name, item);
        }
    }
    public int LoadItem(int index)
    {
        int item = PlayerPrefs.GetInt($"Res{index}");
        return item;
    }
    public int GetRes(ItemId name)
    {
        int result = LoadItem((int) name);
        return result;
    }
    public void LoadData()
    {
        items.Clear();
        int enumCount = System.Enum.GetValues(typeof(ItemId)).Length;
        for (int i = 0; i < enumCount; i++)
        {
            items.Add(PlayerPrefs.GetInt($"Res{i}"));
        }
    }
}
public enum ItemId : int
{
    None = -1,
    Cotton = 0,
    Linen = 1,
    OldCloth = 2,
    Wood = 3,
    BestWood = 4,
    Stone = 5,
    Metal = 6,
    Bronze = 7,
    Silver = 8,
    Gold = 9,
    Detail1 = 10,
    Detail2 = 11,
    StageDetail = 12,
    Wrench = 13,
    Wiring = 14,
    Aluminum = 15,
    Cloth = 16,
    EliteCloth = 17,
    Lubricant = 18,
    Cooling = 19,
    Videocard = 20,
    Matterial = 21,
    Bottle = 22,
    DistilledWater = 23,
    Rake = 24,
    Chainsaw = 25,
    Pick = 26,
    InstrumentBag = 27,
    AdditionalHands = 28,
    KolenvalImprove = 29,
    KppImprove = 30,
    NagnetatelImprove = 31,
    TurbocompressorImprove = 32,
    KolenvalSport = 33,
    KppSport = 34,
    NagnetatelSport = 35,
    TurbocompressorSport = 36,
    KolenvalSportPlus = 37,
    KppSportPlus = 38,
    NagnetatelSportPlus = 39,
    TurbocompressorSportPlus = 40,
    BoxSimpleCar = 41,
    BoxWithBonus = 42,
    BoxSuperCar = 43,
    BoxLuxury = 44,
    ToolBox = 45,
    RandonCarBox = 46,
    BestCarsBox = 47
}
