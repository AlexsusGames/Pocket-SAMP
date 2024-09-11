using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class EnemyDataFinder 
{
    private SoEnemiesData[] enemies => Resources.LoadAll<SoEnemiesData>("Enemies");
    private Dictionary<string, SoEnemiesData> enemiesMap = new();

    public EnemyDataFinder() => CreateMap();
    private void CreateMap()
    {
        foreach (var enemy in enemies)
        {
            enemiesMap[enemy.EnemyName] = enemy;
        }
    }
    public SoEnemiesData FindByName(string name) => enemiesMap[name];
}
