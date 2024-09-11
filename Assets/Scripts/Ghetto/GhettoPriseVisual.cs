using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GhettoPriseVisual : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text moneyReward;
    [SerializeField] private TMP_Text respectReward;
    [SerializeField] private AccessoryButtonVisual accessoryButton;

    public void SetData(SoEnemiesData enemyData,SoAccessory accessoryData = null)
    {
        nameText.text = enemyData.EnemyName;
        moneyReward.text = $"{enemyData.Reward}$";
        respectReward.text = $"{enemyData.RespectReward}î.ó";
        if (accessoryData == null) accessoryButton.gameObject.SetActive(false);
        else
        {
            accessoryButton.gameObject.SetActive(true);
            accessoryButton.SetData(accessoryData);
        }
    }
}
