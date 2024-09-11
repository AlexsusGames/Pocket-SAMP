using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MiningData 
{
    public Videocard[] Videocards;

    public MiningData()
    {
        Videocards = new Videocard[4];
        for (int i = 0; i < Videocards.Length; i++)
        {
            Videocards[i] = new();
        }
    }
}
[System.Serializable]
public class Videocard
{
    public int Level = 0;
    public float Profit => Level * 0.3f;
    public float CoolingBar;
    public float KeepingAz;
}
