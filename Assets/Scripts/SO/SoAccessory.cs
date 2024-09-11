using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoAccessoryData",menuName = "Create/SoAccessory")]
public class SoAccessory : ScriptableObject
{
    public string Name;
    public Sprite sprite;
    public int Damage;
    public SlotRarity Rarity;
}
