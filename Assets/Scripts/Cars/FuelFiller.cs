using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelFiller 
{
    private CarDataLoader carDataLoader = new();
    private WaitForSeconds time = new(1);
    public static Action<int> Seconds;
    public static Action OnFuel;
    private int seconds;
    private CarsProgress carsData;

    private void FillAvailableCars()
    {
        carsData = carDataLoader.GetCarList();
        for (int i = 0; i < carsData.progress.Count; i++)
        {
            if (carsData.progress[i].Fuel < 10) carsData.progress[i].Fuel += 2;
            if (carsData.progress[i].Fuel > 10) carsData.progress[i].Fuel = 10;
        }
        carDataLoader.SaveData();
    }
    private int LoadTime()
    {
        int time = PlayerPrefs.GetInt("FuelTimer");
        return time;
    }
    public void SaveTime()
    {
        PlayerPrefs.SetInt("FuelTimer", seconds);
    }

    public IEnumerator FuelTimer(int timer)
    {
        while (true)
        {
            int remainingTime = LoadTime();
            seconds = remainingTime <= 0 ? timer : remainingTime;
            while (seconds > 0)
            {
                yield return time;
                seconds--;
                Seconds?.Invoke(seconds);
            }
            SaveTime();
            FillAvailableCars();
            OnFuel?.Invoke();
        }
    }
}
