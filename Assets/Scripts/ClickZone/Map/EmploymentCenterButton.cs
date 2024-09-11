using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmploymentCenterButton : MonoBehaviour
{
    [SerializeField] private TMP_Text payment;
    [SerializeField] private TMP_Text rang;
    [SerializeField] private TMP_Text buttonText;
    [SerializeField] private int needRespects;
    [SerializeField] private Button button;
    [SerializeField] private SoWork work;
    private WorkDataChanger data = new WorkDataChanger();
    private Wallet wallet = new Wallet();
    public static Action OnUpdate;

    private void OnEnable() => OnUpdate += SetData;
    private void OnDisable() => OnUpdate -= SetData;
    private void Start()
    {
        SetData();
    }
    public void SetData()
    {
        WorkProgress progress = data.GetWorkProgress(work.WorkId);
        float bonusByRang = (float)progress.Rang / 10 + 1;
        payment.text = $"{(int)(work.MinPayment * bonusByRang)} - {(int)(work.MaxPayment * bonusByRang)}$";
        if (progress.IsEmployment)
        {
            button.onClick.RemoveAllListeners();
            rang.text = $"{progress.Rang} ранг.";
            button.gameObject.SetActive(false);
        }
        else
        {
            button.gameObject.SetActive(true);
            button.onClick.AddListener(Employ);
            rang.text = $"Нужно {needRespects} о.у";
            button.image.color = Color.green;
            buttonText.text = "Устроиться";
        }
    }
    public void Employ()
    {
        if(wallet.GetRespects() >= needRespects)
        {
            data.ChangeWork(work.WorkId);
            SetData();
            OnUpdate?.Invoke();
        }
    }
}
