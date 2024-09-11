using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VipStatus 
{
    private const string Key = "KeyVip";

    public bool GetVip()
    {
        if (PlayerPrefs.GetInt(Key) > 0) return true;
        else return false;
    }
    public void ButVip()
    {
        PlayerPrefs.SetInt(Key, 1);
        PlayerPrefs.Save();
    }
}
