using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy",menuName = "Create/NewEnemy")]
public class SoEnemiesData : ScriptableObject
{
    public string EnemyName;
    public List<SoAccessory> Accessories = new();
    public Sprite sprite;
    public int MaxHealth;
    public int Reward;
    public int NeedRespect;
    public int RespectReward;
}
