using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkinData 
{
    public List<SkinProgress> progress = new List<SkinProgress>();
}
[System.Serializable]
public class SkinProgress
{
    public bool IsOpen;
    public int Price;
    public string Character;
    public string Name;
}
