using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BusinessData 
{
    public List<BusinessProgress> progress = new List<BusinessProgress>();
}
[System.Serializable]
public class BusinessProgress
{
    public bool IsOpen;
    public float ImproveFactor;
    public bool IsFullImproved;
}
