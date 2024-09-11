using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessDataChanger 
{
    private BusinessData data = new BusinessData();
    private const string Key = "BusinessSave";
    private const int BusinessCount = 11;

    private void SaveData()
    {
        string save = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(Key, save);
        PlayerPrefs.Save();
    }
    private void LoadData()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            string save = PlayerPrefs.GetString(Key);
            data = JsonUtility.FromJson<BusinessData>(save);
        }
        else CreateData();
    }
    private void CreateData()
    {
        for (int i = 0; i < BusinessCount; i++)
        {
            data.progress.Add(new BusinessProgress());
            data.progress[i].ImproveFactor = 1;
        }
        SaveData();
    }
    public void ImproveBusinessLevel(int index)
    {
        LoadData();
        data.progress[index].ImproveFactor += 0.1f;
        if (data.progress[index].ImproveFactor >= 2.0f)
            data.progress[index].IsFullImproved = true;
        SaveData();
    }
    public float GetImpoveFactor(int index)
    {
        LoadData();
        return data.progress[index].ImproveFactor;
    }
    public bool IsOpened(int index)
    {
        LoadData();
        return data.progress[index].IsOpen;
    }
    public void OpenBusiness(int index)
    {
        LoadData();
        data.progress[index].IsOpen = true;
        SaveData();
    }
    public BusinessProgress GetProgress(int index)
    {
        LoadData();
        return data.progress[index];
    }
}
