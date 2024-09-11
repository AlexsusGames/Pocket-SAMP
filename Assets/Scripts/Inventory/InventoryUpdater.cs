using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUpdater : MonoBehaviour
{
    [SerializeField] private List<Button> buttonList = new List<Button>();
    [SerializeField] private SoResourcesInfo sprites;
    [SerializeField] private Sprite nullSprite;
    private List<int> resourcesIndexes = new List<int>();
    private InventoryDataLoader data = new InventoryDataLoader();
    private ItemsData itemData = new ItemsData();

    private void OnDisable() => InventoryPlaceChanger.onChange -= Fulling;
    private void OnEnable() 
    {
        InventoryPlaceChanger.onChange += Fulling;
        resourcesIndexes = itemData.GetItemList();
        Invoke(nameof(Fulling), 0.01f);
        Invoke(nameof(Fulling), 0.1f);
    }
    private void Fulling()
    {
        ClearList();
        for (int i = 0; i < resourcesIndexes.Count; i++)
        {
            if (resourcesIndexes[i] != 0)
            {
                int resourcesCount = resourcesIndexes[i];
                float countOfCells = (float)resourcesIndexes[i] / 1000;
                for (int count = 0; count < (int)countOfCells; count++)
                {
                    if(GetFreeCell((ItemId)i) > -1)
                    {
                        buttonList[GetFreeCell((ItemId)i)].TryGetComponent(out InventoryCell cell);
                        cell.SetData(sprites.GetResSprite((ItemId)i), 1000);
                        resourcesCount -= 1000;
                    }
                }
                if (resourcesCount != 0)
                {
                    if (GetFreeCell((ItemId)i) > -1)
                    {
                        buttonList[GetFreeCell((ItemId)i)].TryGetComponent(out InventoryCell cell);
                        cell.SetData(sprites.GetResSprite((ItemId)i), resourcesCount);
                    }
                }
            }
        }
        CheckEmptyCells();
    }
    private int GetFreeCell(ItemId res)
    {
        var dataList = data.GetCellData().cells;
        for (int i = 0;i < buttonList.Count;i++)
        {
            buttonList[i].TryGetComponent(out InventoryCell cell);
            if (cell.GetStatus() == false && dataList[i].ItemId == res) return i;
        }
        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].TryGetComponent(out InventoryCell cell);
            if (cell.GetStatus() == false && dataList[i].ItemId == ItemId.None)
            {
                data.FullingCell(i, res);
                return i;
            }
        }
        Debug.Log("Error");
        return -1;
    }
    private void ClearList()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            buttonList[i].TryGetComponent(out InventoryCell cell);
            cell.ClearCell(nullSprite);
        }
    }
    private void CheckEmptyCells()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            if (buttonList[i].GetComponent<InventoryCell>().GetStatus() == false)
            {
                data.FullingCell(i, ItemId.None); 
            }
        }
    }
    public void SortInventory()
    {
        data.DeleteSave();
        Fulling();
    }
}
