using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryData 
{
    public List<Cell> cells = new List<Cell>();
}
[System.Serializable]
public class Cell
{
    public ItemId ItemId = ItemId.None;
}
