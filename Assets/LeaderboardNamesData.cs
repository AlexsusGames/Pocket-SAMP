using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardNamesData 
{
    private const string Key = "LeadersNamesKey";
    private ChatActions chatActions = new();
    private NamesData data = new();

    private void SaveData()
    {
        string save = JsonConvert.SerializeObject(data);
        PlayerPrefs.SetString(Key, save);
        PlayerPrefs.Save();
    }
    private void LoadData()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            string save = PlayerPrefs.GetString(Key);
            data = JsonConvert.DeserializeObject<NamesData>(save);
        }
    }
    public string AddName(string name)
    {
        LoadData();
        if(!data.LeaderboardNames.ContainsKey(name))
        {
            data.LeaderboardNames[name] = CreateName();
            SaveData();
        }
        return data.LeaderboardNames[name];
    }
    private string CreateName()
    {
        for (int i = 0; i < chatActions.playersNamesForStats.Count; i++)
        {
            if (!data.LeaderboardNames.ContainsValue(chatActions.playersNamesForStats[i]))
            {
                return chatActions.playersNamesForStats[i];
            }
        }
        return chatActions.playersNamesForStats[Random.Range(0, chatActions.playersNamesForStats.Count)];
    }
}
[System.Serializable]
public class NamesData
{
    public Dictionary<string, string> LeaderboardNames = new();
}

