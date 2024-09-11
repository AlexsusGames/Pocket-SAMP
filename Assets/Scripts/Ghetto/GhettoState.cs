using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhettoState 
{
    private const string Key = "GHETTO_STATE_DATA";
    private GhettoStateData data;
    private SoEnemiesData enemy;
    public static Action<GhettoStateData> OnChange;

    public GhettoState()
    {
        
    }
    public GhettoState(SoEnemiesData enemyData)
    {
        ClearEnemy();
        enemy = enemyData;
        UpdateView();
    }
    public void SaveState()
    {
        string save = JsonUtility.ToJson(data);
        PlayerPrefs.SetString(Key, save);
        PlayerPrefs.Save();
    }
    public void UpdateView()
    {
        LoadState();
        OnChange?.Invoke(data);
    }
    private void LoadState()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            string save = PlayerPrefs.GetString(Key);
            data = JsonUtility.FromJson<GhettoStateData>(save);
        }
        else
        {
            if(enemy != null)
            {
                data = new(enemy);
                SaveState();
            }
            else data = null;
        }
    }
    public GhettoStateData GetState()
    {
        LoadState();
        return data;
    }
    public void ClearEnemy()
    {
        PlayerPrefs.DeleteKey(Key);
    }

}
