using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightVisual : MonoBehaviour
{
    [SerializeField] private Image enemyImage;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Image healthBarImage;
    [SerializeField] private ChatLog chatLog;
    public GhettoStateData State { get; private set; }
    private EnemyDataFinder enemyDataFinder;

    private void OnEnable() => GhettoState.OnChange += UpdateInfo;
    private void OnDisable() => GhettoState.OnChange -= UpdateInfo;
    private void UpdateInfo(GhettoStateData data)
    {
        enemyDataFinder = new();
        var enemyData = enemyDataFinder.FindByName(data.EnemyName);
        enemyImage.sprite = enemyData.sprite;
        healthBarImage.fillAmount = (float)data.CurrentHealth / enemyData.MaxHealth;
        healthText.text = data.CurrentHealth.ToString();
        FillChat(data.ChatMessages);
        State = data;
    }
    private void FillChat(List<string> messages)
    {
        chatLog.ClearChat();
        for(int i  = 0; i < messages.Count; i++)
        {
            chatLog.AddMesage(messages[i]);
        }
    }
}
