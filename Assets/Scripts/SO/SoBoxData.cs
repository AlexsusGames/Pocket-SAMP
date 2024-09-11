using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create/BoxData", fileName = "BoxData")]
public class SoBoxData : ScriptableObject
{
    public bool donateBox;
    public int DropId;
    public ItemId BoxID;
    public SoCarData[] cars;
    public SoBoxDrop drop;
    [HideInInspector]public SlotBoxData[] slots = new SlotBoxData[21];
    private ItemsData data = new ItemsData();
    public static Action OnRewarding;
    public static Action OnBoxEnd;

    public void UpdateBoxData()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new SlotBoxData(DropId,cars,BoxID,drop);
        }
    }
    public void GiveRewards()
    {
        if(data.GetRes(BoxID) > 0)
        {
            slots[18].GiveReward();
            data.ChangeRes(BoxID, -1);
            OnRewarding?.Invoke();
            if(data.GetRes(BoxID) == 0)
            {
                OnBoxEnd?.Invoke();
            }
        }
    }
}
