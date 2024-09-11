using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GarageManager : MonoBehaviour
{
    [SerializeField] private Image carImage;
    [SerializeField] private TMP_Text carName;
    [SerializeField] private TMP_Text speedText;
    [SerializeField] private TMP_Text accelerationText;
    [SerializeField] private GameObject carDescribtion;
    private CarDataLoader data = new CarDataLoader();
    private List<SoCarData> cars = new List<SoCarData>();
    private int carIndex;
    [SerializeField] private List<SelectedTuning> tuns = new List<SelectedTuning>();
    [SerializeField] private SoResourcesInfo info;
    [SerializeField] private Sprite standartSprite;
    private CarStatsCalculater carsStats = new CarStatsCalculater();

    private void OnEnable()
    {
        GetCars();
        if (cars.Count == 0)
        {
            carDescribtion.SetActive(false);
        }
        else
        {
            UpdateInfo();
            carDescribtion.SetActive(true);
        }
        SelectedTuning.OnChange += UpdateInfo;
    }

    private void OnDisable() => SelectedTuning.OnChange -= UpdateInfo;

    private void GetCars()
    {
        cars.Clear(); 
        SoCarData[] allCars = Resources.LoadAll<SoCarData>("Cars");
        CarsProgress carsData = data.GetCarList();
        for (int i = 0; i < allCars.Length; i++)
        {
            int index = allCars[i].Index;
            if (carsData.progress[index].IsOpen)
            {
                cars.Add(allCars[i]);
            }
        }
    }
    private void SetData(SoCarData carData)
    {
        if(carData != null)
        {
            carImage.sprite = carData.SideSprite;
            carName.text = carData.Name;
            float speed = carsStats.GetSpeed(carData.Speed, data.GetAllTuning(carData.Index));
            float speedRounded = (float)Math.Round(speed, 1);
            speedText.text = $"Скорость: <color=green>{speedRounded}км.ч.";
            float acceleration = carsStats.GetAcceleration(carData.Acceleration, data.GetAllTuning(carData.Index));
            float accelerationRounded = (float)Math.Round(acceleration, 1);
            accelerationText.text = $"Разгон: <color=green>{accelerationRounded}сек.";
            ShowTun(data.GetCarList().progress[carData.Index]);
        }
    }
    public void ChangeIndex(int index)
    {
        carIndex += index;
        if (carIndex < 0) carIndex = cars.Count - 1;
        else if (carIndex > cars.Count - 1) carIndex = 0;
        SetData(cars[carIndex]);
    }
    private void ShowTun(CarProgress progress)
    {
        for (int i = 0;i < tuns.Count;i++)
        {
            if (progress.Tunning[i] != 0)
            {
                tuns[i].SetData(progress.Tunning[i], cars[carIndex].Index, info.GetResSprite(progress.Tunning[i]));
            }
            else tuns[i].SetData(progress.Tunning[i], cars[carIndex].Index, standartSprite);
        }
    }
    private void UpdateInfo()
    {
        if (cars.Count != 0) 
        SetData(cars[carIndex]);
    }
    public void LoadRaceScene()
    {
        SceneManager.LoadScene(4);
        PlayerPrefs.SetInt("Location",(int)Locations.Race);
        LoadScreen.instance.ShowLoadScreen(0.5f);
    }
}
