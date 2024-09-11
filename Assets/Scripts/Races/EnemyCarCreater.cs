using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarCreater 
{
    private ItemId[] allTheTuning = new ItemId[12];
    private SoCarData[] soCars;
    private List<SoCarData> rangeCars = new List<SoCarData>();
    private int offset = 50;
    public CarProgress GetEnemyData(int difficult)
    {
        GetTuning();
        ItemId[] tuns = new ItemId[4];
        for (int i = 0; i < tuns.Length; i++)
        {
            if (difficult + i > -1)
            tuns[i] = allTheTuning[difficult + i];
        }
        CarProgress data = new CarProgress();
        data.Tunning = tuns;
        return data;
    } 
    private void GetTuning()
    {
        int firstElement = (int)ItemId.KolenvalImprove;
        for (int i = 0; i < allTheTuning.Length; i++)
        {
            allTheTuning[i] = (ItemId)firstElement;
            firstElement++;
        }
    }
    private void LoadCar()
    {
        soCars = Resources.LoadAll<SoCarData>("Cars");
    }
    private void SortCars(int speedRange)
    {
        int count = 0; 
        rangeCars.Clear();
        if(soCars == null) LoadCar();
        for(int i = 0;i < soCars.Length; i++)
        {
            if (soCars[i].Speed < speedRange && soCars[i].Speed > speedRange - offset)
            {
                rangeCars.Add(soCars[i]);
                count++;
            }
        }
        Debug.Log($"Loaded enemy cars - {count}");
    }
    public SoCarData GetCarForRange(int speedRange)
    {
        SortCars(speedRange);
        return rangeCars[Random.Range(0, rangeCars.Count)];
    }

}
