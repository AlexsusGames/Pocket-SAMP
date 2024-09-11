using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create/NewWork",fileName = "Work")]
public class SoWork : ScriptableObject
{
    public int WorkId;
    public ItemId[] UsualItems;
    public ItemId Rareitem;
    public int NeedHouse;
    public int NeedSkin;
    public bool IsCanEmploy;
    public int MinPayment;
    public int MaxPayment;
    public int HouseLevel;
    public int GetPaiment() => Random.Range(MinPayment, MaxPayment);

    public ItemId GetItem()
    {
        int random = Random.Range(1, 101);
        if (random > 50) return UsualItems[1];
        else return UsualItems[0];
    }
}
