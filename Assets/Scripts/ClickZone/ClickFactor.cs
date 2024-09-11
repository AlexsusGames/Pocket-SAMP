using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFactor 
{
    private ItemId[] improves = { ItemId.Rake, ItemId.Chainsaw, ItemId.Pick, ItemId.InstrumentBag, ItemId.AdditionalHands };
    public int Factor { get; private set; }
    private ItemsData items = new();
    private int factor;

    public ClickFactor(int workId)
    {
        if(workId < improves.Length)
        Factor = items.GetRes(improves[workId]) > 0 ? 2 : 1;
        else Factor = 1;
        factor = Factor;
    }
    public void EnableX4(bool value)
    {
        Factor = value ? 4 : factor;
    }
}