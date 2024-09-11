using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AzMining 
{
    private HouseDataLoader loader = new();

    public float GetKeepingAz()
    {
        float amount = 0;
        var videocards = loader.GetHomeVideocards();
        for (int i = 0; i < videocards.Count; i++)
        {
            amount += videocards[i].KeepingAz;
        }
        return amount;
    }
    public void VideocardsWorking()
    {
        var videocards = loader.GetAllVideocards();
        for (int i = 0; i < videocards.Count; i++)
        {
            if (videocards[i].CoolingBar >= 0.1f)
            {
                videocards[i].KeepingAz += videocards[i].Profit;
                videocards[i].CoolingBar -= 0.1f;
                loader.SaveData();
            }
        }
    }
}
