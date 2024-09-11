using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsData 
{
    private const string KeyEat = "EatSave";
    private const string KeySleep = "SleepSave";
    private int eatStat;
    private int sleepStat;


    private void SaveData()
    {
        PlayerPrefs.SetInt(KeyEat, eatStat);
        PlayerPrefs.SetInt(KeySleep, sleepStat);
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey(KeyEat))
        {
            eatStat = PlayerPrefs.GetInt(KeyEat);
            sleepStat = PlayerPrefs.GetInt(KeySleep);
        }
        else CreateData();
    }
    private void CreateData()
    {
        eatStat = 1000;
        sleepStat = 1000;
        SaveData();
    }
    public IEnumerator Timer()
    {
        LoadData();
        while (true)
        {
            if (eatStat > 0) eatStat -= 2;
            if(sleepStat < 1000) sleepStat += 5;
            SaveData();
            yield return new WaitForSeconds(1);
        }
    }
    public int GetSleapData()
    {
        LoadData();
        return sleepStat;
    }
    public int GetEatNeed()
    {
        return eatStat;
    }
    public int GetSleepNeed()
    {
        return sleepStat;
    }
    public void DoAction()
    {
        if (sleepStat <= 1000)
        sleepStat -= 5;
        Debug.Log(sleepStat);
    }
    public void SetEatStat(int value)
    {
        eatStat += value;
        if (eatStat > 1000) eatStat = 1000;
        SaveData() ;
    }
    public void SetSleepStat(int value)
    {
        sleepStat += value;
        if(sleepStat > 1000) sleepStat = 1000;
        SaveData() ;
    }
    
}
