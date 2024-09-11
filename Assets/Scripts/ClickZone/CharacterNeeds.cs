using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterNeeds : MonoBehaviour
{
    [SerializeField] private Image eatImage;
    [SerializeField] private Image sleepImage;
    private VipStatus vip = new VipStatus();
    public NeedsData data = new NeedsData();
    public static Action<string> onTired;
    public static Action onFull;

    private void Awake()
    {
        StartCoroutine(data.Timer());
    }
    private void FixedUpdate()
    {
        UpdateInfo();
    }
    private void UpdateInfo()
    {
        if (eatImage != null)
        {
            eatImage.fillAmount = (float)data.GetEatNeed() / 1000;
        }
        if (sleepImage != null)
        {
            sleepImage.fillAmount = (float)data.GetSleepNeed() / 1000;
        }
        if (data.GetEatNeed() < 100) onTired?.Invoke("<color=red>Для того чтобы работать вам нужно поесть!");
        else if (data.GetSleepNeed() < 100) onTired?.Invoke("<color=red>Для того чтобы работать вам нужно отдохнуть!");
        else if (data.GetEatNeed() > 200 && data.GetSleepNeed() > 200) onFull?.Invoke();
    }
    public void DoAction()
    {
        if(!vip.GetVip())
        data.DoAction();
    }
    public bool SetEat(int value)
    {
        if(data.GetEatNeed() < 700)
        {
            data.SetEatStat(value);
            return true;
        }
        return false;
    }
    public bool SetSleep(int value)
    {
        if(data.GetSleepNeed() < 950)
        {
            data.SetSleepStat(value);
            return true;
        }
        return false;
    }
    public bool isHungry()
    {
        if(data.GetEatNeed() < 300)
        {
            return true;
        }
        return false;
    }
}
