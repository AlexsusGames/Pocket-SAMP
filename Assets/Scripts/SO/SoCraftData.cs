using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create/CraftData", menuName = "CraftData")]
public class SoCraftData : ScriptableObject
{
    public List<ItemId> Resources = new List<ItemId>();
    public List<int> ResourcesCount = new List<int>();
    [Range(1,100)]public int CraftChance;
    public Sprite ItemSprite;
    public ItemId CraftItem;
    public int WorkbenchLevel;
}
