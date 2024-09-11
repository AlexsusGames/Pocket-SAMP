using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalDropChance 
{
    private const string Key = "ChanceKey";

    public int GetAdditionalChance()
    {
        int chance = (int)PlayerPrefs.GetFloat(Key);
        Debug.Log($"Current AddChance: {chance}");
        return chance;
    }

    public void ImproveChance()
    {
        float current = PlayerPrefs.GetFloat(Key);
        PlayerPrefs.SetFloat(Key, current + 0.1f);
    }

    public void SetDefault()
    {
        PlayerPrefs.SetFloat(Key, 0f);
        PlayerPrefs.Save();
    }
}
