using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaceCarChanger : MonoBehaviour
{
    [SerializeField] private GameObject ads;
    [SerializeField] private RaceManager raceManager;
    [SerializeField] private RaceCarVisual carVisual;
    public event Action<SoCarData,CarProgress> OnCarChange;
    private SoCarData[] allCars => Resources.LoadAll<SoCarData>("Cars");
    private const string Key = "PlayerCar";
    private List<SoCarData> playerCars = new();
    private readonly CarDataLoader data = new();
    private int carIndex = 0;

    private void OnEnable()
    {
        OnCarChange += raceManager.SetPlayerData;
        OnCarChange += carVisual.UpdateVisual;
    }
    private void OnDisable()
    {
        OnCarChange -= raceManager.SetPlayerData;
        OnCarChange -= carVisual.UpdateVisual;
    }
    private void Awake()
    {
        SortOpenCars();
        var playerCar = GetPlayerCar();
        carIndex = playerCars.IndexOf(playerCar);
    }
    private void Start() => SetPlayerCar(playerCars[carIndex]);
    private SoCarData GetPlayerCar()
    {
        var carList = data.GetCarList();
        if (playerCars.Count != 0)
        {
            for (int i = 0; i < playerCars.Count; i++)
            {
                if (playerCars[i].Index == PlayerPrefs.GetInt(Key))
                {
                    if (carList.progress[playerCars[i].Index].IsOpen)
                    {
                        return playerCars[i];
                    }
                }
            }
            PlayerPrefs.SetInt(Key, playerCars[carIndex].Index);
            return playerCars[carIndex];
        }
        return null;
    }
    private void SortOpenCars()
    {
        var carsData = data.GetCarList();
        for (int i = 0; i < allCars.Length; i++)
        {
            if (carsData.progress[allCars[i].Index].IsOpen) playerCars.Add(allCars[i]);
        }
    }
    private void SetPlayerCar(SoCarData carData)
    {
        PlayerPrefs.SetInt(Key, carData.Index);
        var carProgress = data.GetCarData(carData.Index);
        ads.SetActive(carProgress.Fuel < 5);
        OnCarChange?.Invoke(carData, carProgress);
    }
    public void ChangeCar(int count)
    {
        carIndex += count;
        if(carIndex > playerCars.Count - 1) carIndex = 0;
        if(carIndex < 0) carIndex = playerCars.Count - 1;
        SetPlayerCar(playerCars[carIndex]);
    } 
    public void FillCar()
    {
        data.FillCar(playerCars[carIndex].Index);
        SetPlayerCar(playerCars[carIndex]);
    }
}
