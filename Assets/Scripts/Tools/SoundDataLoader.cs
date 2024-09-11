using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDataLoader 
{
    private const string Key = "SOUNDkEY";
    private SoundData soundData;

    private void SaveData()
    {
        string save = JsonUtility.ToJson(soundData);
        PlayerPrefs.SetString(Key, save);   
    }
    private void LoadData()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            string save = PlayerPrefs.GetString(Key);
            soundData = JsonUtility.FromJson<SoundData>(save);
        }
        else CreateData();
    }
    private void CreateData()
    {
        soundData = new SoundData();
        soundData.MusicValue = 0.5f;
        soundData.MusicValue = 0.5f;
        SaveData();
    }
    public SoundData GetSoundData()
    {
        LoadData();
        return soundData;
    }
    public void ChangeSoundSettings(float musicValue, float soundValue)
    {
        if (soundData == null)
        {
            LoadData();
        }
        soundData.MusicValue = musicValue;
        soundData.SoundValue = soundValue;
        SaveData();
    }
}
