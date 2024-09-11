using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class CarsProgress 
{
    public List<CarProgress> progress = new List<CarProgress>();
}
[System.Serializable]
public class CarProgress
{
    public bool IsOpen;
    public ItemId[] Tunning = new ItemId[4];
    public int Fuel;
}
