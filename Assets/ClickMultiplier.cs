using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickMultiplier : MonoBehaviour
{
    [SerializeField] private TMP_Text timetext;
    [SerializeField] private Button button;
    private int remainingSeconds;
    private const string Key = "RemainingTimeKey";
    private WaitForSeconds second = new(1f);
    private ClickFactor _factor;

    public void SetData(ClickFactor factor)
    {
        _factor = factor;
        remainingSeconds = PlayerPrefs.GetInt(Key);
        if (remainingSeconds > 0)
        {
            StartMultiplier(remainingSeconds);
        }
    }
    private void UpdateVisual(int time)
    {
        TimeSpan timer = TimeSpan.FromSeconds(time);
        string timerString = timer.ToString(@"mm\:ss");
        if (time != 0)
            timetext.text = timerString;
        else timetext.text = "00:30";
    }
    public void StartMultiplier(int time)
    {
        StartCoroutine (Timer(time));
    }
    private IEnumerator Timer(int time)
    {
        _factor.EnableX4(true);
        button.interactable = false;
        remainingSeconds = time;
        while(remainingSeconds > 0 )
        {
            remainingSeconds--;
            UpdateVisual(remainingSeconds);
            yield return second;
        }
        _factor.EnableX4(false);
        button.interactable = true;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        PlayerPrefs.SetInt(Key, remainingSeconds);
    }
}
