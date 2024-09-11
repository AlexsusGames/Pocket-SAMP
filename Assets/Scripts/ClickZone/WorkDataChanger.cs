using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkDataChanger 
{
    private const string Key = "WorkData";
    private WorkData workData = new WorkData();
    private SoWork[] works => Resources.LoadAll<SoWork>("Works");

    private void SaveData()
    {
        string save = JsonUtility.ToJson(workData);
        PlayerPrefs.SetString(Key, save);
        PlayerPrefs.Save();
    }
    private void LoadData()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            string save = PlayerPrefs.GetString(Key);
            workData = JsonUtility.FromJson<WorkData>(save);
        }
        else CreateData();
    }
    private void CreateData()
    {
        for (int i = 0; i < works.Length; i++)
        {
            workData.progress.Add(new WorkProgress());
            workData.progress[i].IsCanEmploy = works[i].IsCanEmploy;
            workData.progress[i].Rang = 1;
        }
        SaveData();
    }
    private void LeaveAllWork()
    {
        for(int i = 0;i < workData.progress.Count; i++)
        {
            workData.progress[i].Rang = 1;
            workData.progress[i].IsEmployment = false;
        }
    }
    public bool IsHouseAvailable(int index)
    {
        if (works[index].NeedHouse <= PlayerPrefs.GetInt("House")) return true;
        else return false;
    }
    public bool CheckEmployee(int index)
    {
        LoadData();
        return workData.progress[index].IsEmployment;
    }
    public void ChangeWork(int index)
    {
        LoadData();
        LeaveAllWork();
        workData.progress[index].IsEmployment = true;
        SaveData();
    }
    public void UpRang(int index)
    {
        LoadData();
        workData.progress[index].Rang++;
        SaveData();
    }
    public int GetRang(int index)
    {
        LoadData();
        return workData.progress[index].Rang;
    }
    public WorkProgress GetWorkProgress(int index)
    {
        LoadData();
        return workData.progress[index];
    }
}
