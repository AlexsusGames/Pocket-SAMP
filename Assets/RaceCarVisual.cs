using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaceCarVisual : MonoBehaviour
{
    [SerializeField] private Image carImage;
    [SerializeField] private TMP_Text carName;
    [SerializeField] private TMP_Text carFuel;
    [SerializeField] private TMP_Text fillTimer;
    private int carIndex;
    private readonly CarDataLoader data = new();

    private void OnEnable()
    {
        FuelFiller.Seconds += UpdateTimer;
        FuelFiller.OnFuel += UpdateFuelCount;
    }
    public void UpdateVisual(SoCarData carData, CarProgress data)
    {
        carImage.sprite = carData.SideSprite;
        carName.text = carData.Name;
        carFuel.text = $"{data.Fuel * 10}%";
        carIndex = carData.Index;
    }

    private void UpdateTimer(int count)
    {
        TimeSpan time = TimeSpan.FromSeconds(count);
        fillTimer.text = time.ToString(@"m\:ss");
    }
    public void UpdateFuelCount()
    {
        int fuel = data.GetCarData(carIndex).Fuel;
        string txt = fuel > 0 ? $"{fuel}0%" : "0%";
        carFuel.text = txt;
    }
}
