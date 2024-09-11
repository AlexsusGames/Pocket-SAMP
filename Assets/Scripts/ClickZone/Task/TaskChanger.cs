using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskChanger : MonoBehaviour
{
    [SerializeField] private ChatLog log;
    private TaskLoader taskLoader = new TaskLoader();
    private GetItemInfo GetItemInfo = new GetItemInfo();
    private Wallet wallet = new Wallet();

    private void Start()
    {
        WorkPayment.Payment += taskLoader.ChangeCount;
        TaskLoader.OnRewards += RewadsMessage;
        taskLoader.GetTask();
    }
    private void OnDisable()
    {
        WorkPayment.Payment -= taskLoader.ChangeCount;
        TaskLoader.OnRewards -= RewadsMessage;
    }
    private void RewadsMessage()
    {
        log.AddMesage($"<color=yellow>[Награда] Вы получили {GetItemInfo.GetItemName(taskLoader.GetTask().ItemReward)} в свой инвентарь. Поздравляем!");
        log.AddMesage($"<color=yellow>[Награда] Вы получили {taskLoader.GetTask().AzReward}PS-coins на свой счет!");
    }
    public void SkipTask()
    {
        int skipCost = 500;
        if (wallet.GetMoney() >= skipCost)
        {
            wallet.MoneyOperation(-skipCost);
            taskLoader.DeleteCurrentTask();
        }
    }
}
