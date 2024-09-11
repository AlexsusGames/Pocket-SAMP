using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDataLoader 
{
    private InventoryData data = new InventoryData();
    private const string Key = "InventoryData";
    private const int CellCount = 36;

    private void SaveData()
    {
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(Key, json);
        PlayerPrefs.Save();
    }
    private void LoadData()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            string json = PlayerPrefs.GetString(Key);
            data = JsonUtility.FromJson<InventoryData>(json);
        }
        else CreateData();
    }
    private void CreateData()
    {
        data.cells.Clear();
        for (int i = 0; i < CellCount; i++)
        {
            data.cells.Add(new Cell());
        }
    }
    public InventoryData GetCellData()
    {
        LoadData();
        return data;
    }
    public void ChangePlaces(int index1, int index2)
    {
        LoadData();
        Cell firstCell = data.cells[index1];
        Cell secondCell = data.cells[index2];
        data.cells[index1] = secondCell; 
        data.cells[index2] = firstCell;
        SaveData();
    }
    public void FullingCell(int index, ItemId item)
    {
        LoadData();
        data.cells[index].ItemId = item;
        SaveData();
    }
    public void DeleteSave()
    {
        CreateData();
        SaveData();
    }
}
