using System;
using UnityEngine;

public class InventoryPlaceChanger : MonoBehaviour
{
    private InventoryDataLoader data = new InventoryDataLoader();
    private int index1 = -1;
    private int index2 = -1;
    public static Action onChange;

    private void OnEnable() => InventoryInfoTab.OnShowingInfo += SetStandart;
    private void OnDisable() => InventoryInfoTab.OnShowingInfo -= SetStandart;
    public void ChangeIndexes(int index, bool isFull)
    {
        if (index1 == -1 && isFull)
        {
            index1 = index;
        }
        else if (index2 == -1 && index2 != index1)
        {
            index2 = index;
            data.ChangePlaces(index1, index2);
            onChange?.Invoke();
            SetStandart();
        }
    }
    private void SetStandart()
    {
        index1 = -1;
        index2 = -1;
    }

}
