using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HousesData 
{
    public List<HouseProgress> Houses = new List<HouseProgress>();
}
[System.Serializable]
public class HouseProgress
{
    public int StarsIndex;
    public int Price;
    public bool IsOpen;
    public int WorkbenchLevel;
    public int GarageLevel;
    public MiningData Mining;
}
