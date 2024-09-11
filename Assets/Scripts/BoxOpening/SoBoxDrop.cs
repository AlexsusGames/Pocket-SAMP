using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create/BoxDrop",fileName = "BoxDrop")]
public class SoBoxDrop : ScriptableObject
{
    [SerializeField] private List<ItemId> usualItems = new List<ItemId>();
    [SerializeField] private List<ItemId> rareItems = new List<ItemId>();
    [SerializeField] private List<ItemId> veryRareItems = new List<ItemId>();

    public ItemId GetUsualItem => usualItems[Random.Range(0, usualItems.Count)];
    public ItemId GetRareItem => rareItems[Random.Range(0, rareItems.Count)];
    public ItemId GetVeryRareItem => veryRareItems[Random.Range(0, veryRareItems.Count)];

}
