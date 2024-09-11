using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhettoStatsData 
{
    private const string KEY = "ACCESSORY_DATA";
    private OwnAccessoriesData accessories = new();
    private int standartDamage = 10;

    private void SaveData()
    {
        string save = JsonUtility.ToJson(accessories);
        PlayerPrefs.SetString(KEY, save);
        PlayerPrefs.Save();
    }
    private void LoadData()
    {
        if (PlayerPrefs.HasKey(KEY))
        {
            string save = PlayerPrefs.GetString(KEY);
            accessories = JsonUtility.FromJson<OwnAccessoriesData>(save);
        }
        else
        {
            accessories = new();
            SaveData();
        }
    }
    public bool IsContains(SoAccessory accessory)
    {
        LoadData();
        for (int i = 0; i < accessories.Name.Count; i++)
        {
            if (accessory.Name == accessories.Name[i])
            {
                return true;
            }
        }
        return false;
    }
    public void AddNewAccessory(SoAccessory accessory)
    {
        LoadData();
        accessories.Name.Add(accessory.Name);
        accessories.Damage.Add(accessory.Damage);
        SaveData();
    }
    public int GetDamage()
    {
        int result = standartDamage;
        LoadData();
        foreach(var accessory in accessories.Damage)
        {
            result += accessory;
        }
        return result;
    }
    public List<string> GetNames()
    {
        List<string> names = new List<string>();
        LoadData();
        foreach(var name in accessories.Name)
        {
            names.Add(name);
        }
        return names;
    }
    public void ClearProgress()
    {
        PlayerPrefs.DeleteKey(KEY);
    }
}
[System.Serializable]
public class OwnAccessoriesData
{
    public List<int> Damage = new();
    public List<string> Name = new();
}
