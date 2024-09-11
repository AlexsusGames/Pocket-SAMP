using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create/SoBusiness",fileName = "BusinessData")]
public class SoBusinessData : ScriptableObject
{
    public int Index;
    public string Name;
    public int Profit;
    public int Price;
    public int Upgrade;
    public Sprite Sprite;
}
