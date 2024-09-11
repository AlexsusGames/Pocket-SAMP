using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MiningChanger 
{
    public event Action<MiningData> OnChange;

    private MiningData miningData;

    public MiningChanger(MiningData data)
    {
        miningData = data;
    }
    public bool SetVideocard()
    {
        for (int i = 0;i < miningData.Videocards.Length;i++)
        {
            if (miningData.Videocards[i].Level == 0)
            {
                var videocard = miningData.Videocards[i];
                videocard.Level++;
                OnChange?.Invoke(miningData);
                return true;
            }
        }
        return false;
    }
    public bool ServiceVideocard()
    {
        for (int i = 0; i < miningData.Videocards.Length; i++)
        {
            if (miningData.Videocards[i].Level == 0) continue;
            if (miningData.Videocards[i].CoolingBar < 0.5f)
            {
                var videocard = miningData.Videocards[i];
                videocard.CoolingBar = 1;
                OnChange?.Invoke(miningData);
                return true;
            }
        }
        return false;
    }
    public void ImproveVideocard(int index)
    {
        var videocard = miningData.Videocards[index];
        videocard.Level++;
        OnChange?.Invoke(miningData);
    }
    public int WithdrowAz()
    {
        float totalAz = 0;
        for (int i = 0; i < miningData.Videocards.Length; i++)
        {
            totalAz += miningData.Videocards[i].KeepingAz;
            miningData.Videocards[i].KeepingAz = 0;
        }
        if (totalAz < 1)
        {
            miningData.Videocards[0].KeepingAz = totalAz;
            return 0;
        }
        else
        {
            int canWithdrow = (int)totalAz;
            float remainedAz = totalAz - canWithdrow;
            miningData.Videocards[0].KeepingAz = remainedAz;
            OnChange?.Invoke(miningData);
            return canWithdrow;
        }
    }

}
