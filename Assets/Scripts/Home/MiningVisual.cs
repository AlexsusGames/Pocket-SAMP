using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiningVisual : MonoBehaviour
{
    [SerializeField] private VideocardVisual[] videocardVisuals = new VideocardVisual[4];
    [SerializeField] private TMP_Text textAmount;
    private AzMining mining = new();

    public void SetData(MiningData data)
    {
        for (int i = 0;i < data.Videocards.Length; i++)
        {
            videocardVisuals[i].SetData(data.Videocards[i]);
        }
        Invoke(nameof(UpdateInfo), 0.1f);
    }
    private void UpdateInfo()
    {
        float keepingAz = (float)Math.Round(mining.GetKeepingAz(), 1);
        textAmount.text = $"{keepingAz} PS-coins";
    }
}
