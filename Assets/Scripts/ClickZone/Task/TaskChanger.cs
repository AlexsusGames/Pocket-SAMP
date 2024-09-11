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
        log.AddMesage($"<color=yellow>[�������] �� �������� {GetItemInfo.GetItemName(taskLoader.GetTask().ItemReward)} � ���� ���������. �����������!");
        log.AddMesage($"<color=yellow>[�������] �� �������� {taskLoader.GetTask().AzReward}PS-coins �� ���� ����!");
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
