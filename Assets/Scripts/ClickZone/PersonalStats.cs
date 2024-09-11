using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalStats 
{
    public string MoneyEarnedKey { get; private set; } = "PawnShopEarnedKey";
    public string ItemsSoldKey { get; private set; } =  "ItemsSoldKey";
    public string CasinoWinKey { get; private set; } = "CasinoWinKey";
    public string CasinoLostKey { get; private set; } = "CasinoLostKey";
    public string RaceWinKey { get; private set; } = "RaceWinKey";
    public string RaceLostKey { get; private set; } = "RaceLostKey";
    public string SuccessfulCraftsKey { get; private set; } = "SuccessfulCraftsKey";
    public string UnSuccessfulCraftsKey { get; private set; } = "UnSuccessfulCraftsKey";
    public string BoxOpenedKey { get; private set; } = "BoxOpenedKey";
    public string TaskComplated { get; private set; } = "TaskComplatedKey";
    public string TimePlayed { get; private set; } = "TimePlayedKey";


    public void ChangeStats(int value, string property)
    {
        int current = PlayerPrefs.GetInt(property);
        PlayerPrefs.SetInt(property, current + value);
    }
    public int GetStats(string property)
    {
        return PlayerPrefs.GetInt(property);
    }
}
