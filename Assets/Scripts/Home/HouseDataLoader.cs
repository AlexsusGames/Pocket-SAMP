using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class HouseDataLoader 
{
    private HousesData data = new HousesData();
    private const string Key = "HouseSave";
    private const int HouseCount = 13;

    public void SaveData()
    { 
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(Key, json);
        PlayerPrefs.Save();    
    }
    private void CreateData()
    {
        for (int i = 0; i < HouseCount; i++)
        {
            data.Houses.Add(new HouseProgress());
            data.Houses[i].Mining = new();
            if(i == 0)
            {
                data.Houses[i].StarsIndex = 0;
                data.Houses[i].Price = 0;
            }
            else if (i < 3 && i > 0)
            {
                data.Houses[i].StarsIndex = 0;
                data.Houses[i].Price = 5000;
            }
            else if (i < 6 && i > 2)
            {
                data.Houses[i].StarsIndex = 1;
                data.Houses[i].Price = 25000;
            }
            else if (i < 9 && i > 5)
            {
                data.Houses[i].StarsIndex = 2;
                data.Houses[i].Price = 50000;
            }
            else if (i < 11 && i > 8)
            {
                data.Houses[i].StarsIndex = 3;
                data.Houses[i].Price = 1000000;
            }
            else if(i < 13 && i > 10)
            {
                data.Houses[i].StarsIndex= 4;
                data.Houses[i].Price = 5000000;
            }
        }
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            string json = PlayerPrefs.GetString(Key);
            data = JsonUtility.FromJson<HousesData>(json);
        }
        else CreateData();
    }
    public HousesData GetHouseData()
    {
        LoadData();
        return data;
    }
    public void OpenHouse(int index, bool isOpen)
    {
        if (index > data.Houses.Count)
        {
            LoadData();
            OpenHouse(index, isOpen);
            return;
        }
        data.Houses[index].IsOpen = isOpen;
        SaveData();
    }
    public void ImproveWorkbench(int index, int level)
    {
        if (index > data.Houses.Count)
        {
            LoadData();
            ImproveWorkbench(index, level);
            return;
        }
        data.Houses[index].WorkbenchLevel = level;
        PlayerPrefs.SetInt("Craft", level);
        SaveData();
    }
    public void ImproveGarage(int index, int level)
    {
        if (index > data.Houses.Count)
        {
            LoadData();
            ImproveGarage(index, level);
            return;
        }
        data.Houses[index].GarageLevel = level;
        PlayerPrefs.SetInt("Garage", level);
        SaveData();
    }
    public List<Videocard> GetAllVideocards()
    {
        LoadData();
        List<Videocard> list = new List<Videocard>();
        for (int i = 0; i < data.Houses.Count; i++)
        {
            if (data.Houses[i].Mining != null)
            {
                for (int j = 0; j < data.Houses[i].Mining.Videocards.Length; j++)
                {
                    if (data.Houses[i].Mining.Videocards[j].Level > 0) list.Add(data.Houses[i].Mining.Videocards[j]);
                }
            }
            else
            {
                data.Houses[i].Mining = new();
            }
        }
        SaveData();
        return list;
    }
    public List<Videocard> GetHomeVideocards()
    {
        LoadData();
        List<Videocard> list = new List<Videocard>();
        int houseData = PlayerPrefs.GetInt("House");
        for (int i = 0; i < data.Houses[houseData].Mining.Videocards.Length; i++)
        {
            if (data.Houses[houseData].Mining.Videocards[i].Level > 0) list.Add(data.Houses[houseData].Mining.Videocards[i]);
        }
        return list;
    }
}
