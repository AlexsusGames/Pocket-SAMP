using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GhettoButtonVisual : MonoBehaviour
{
    [SerializeField] private Image enemyImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text rewardMoneyText;
    [SerializeField] private TMP_Text rewardRespectText;
    [SerializeField] private TMP_Text hpText;
    [SerializeField] private TMP_Text needRespectText;
    [SerializeField] private AccessoryButtonVisual[] accessoryReward;
    private GhettoStatsData statsData = new();


    public void SetData(SoEnemiesData data)
    {
        enemyImage.sprite = data.sprite;
        nameText.text = data.EnemyName;
        rewardMoneyText.text = data.Reward.ToString();
        rewardRespectText.text = data.RespectReward.ToString();
        needRespectText.text = data.NeedRespect.ToString();
        hpText.text = data.MaxHealth.ToString();
        for (int i = 0; i < accessoryReward.Length; i++)
        {
            accessoryReward[i].SetData(data.Accessories[i]);
            if (!statsData.IsContains(data.Accessories[i]))
                accessoryReward[i].SetUnlockSprite();
        }
    }
}
