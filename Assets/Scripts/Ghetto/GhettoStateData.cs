using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GhettoStateData 
{
    public string EnemyName;
    public int CurrentHealth;
    public List<string> ChatMessages = new();

    public GhettoStateData(SoEnemiesData data)
    {
        ChatMessages.Clear();
        EnemyName = data.EnemyName;
        CurrentHealth = data.MaxHealth;
    }
}
