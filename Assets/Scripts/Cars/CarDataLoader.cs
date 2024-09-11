using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDataLoader
{
    private const string Key = "Cars";
    private CarsProgress cars = new CarsProgress();
    private SoCarData[] loadedCars;

    public void SaveData()
    {
        string save = JsonUtility.ToJson(cars);
        PlayerPrefs.SetString(Key, save);
        PlayerPrefs.Save();
    }
    private void LoadData()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            string save = PlayerPrefs.GetString(Key);
            cars = JsonUtility.FromJson<CarsProgress>(save);
            if (GetCount() != cars.progress.Count)
            {
                int different = GetCount() - cars.progress.Count;
                for (int i = 0; i < different; i++)
                {
                    var car = new CarProgress();
                    cars.progress.Add(car);
                    car.Fuel = 10;
                }
                SaveData();
            }
        }
        else CreateData();
    }
    private void CreateData()
    {
        cars.progress.Clear();
        for (int i = 0; i < GetCount(); i++)
        {
            cars.progress.Add(new CarProgress());
            cars.progress[i].Fuel = 10;
        }
        SaveData();
    }
    public SoCarData GetSoCar(int index)
    {
        for (int i = 0; i < GetCount(); i++)
        {
            if (loadedCars[i].Index == index) return loadedCars[i];
        }
        return null;
    }
    private int GetCount()
    {
        if (loadedCars == null) loadedCars = Resources.LoadAll<SoCarData>("Cars");
        int count = loadedCars.Length;
        return count;
    }
    public CarsProgress GetCarList()
    {
        LoadData();
        Debug.Log($"Loaded {cars.progress.Count} cars");
        return cars;
    }
    public CarProgress GetCarData(int index)
    {
        LoadData();
        return cars.progress[index];
    }
    public void UnlockCar(int index, bool value)
    {
        LoadData();
        cars.progress[index].IsOpen = value;
        cars.progress[index].Fuel = 10;
        DeleteTuning(index);
        SaveData();
    }
    public void SetTun(int index, int tunIndex, ItemId tuning)
    {
        LoadData();
        cars.progress[index].Tunning[tunIndex] = tuning;
        SaveData();
    }
    public ItemId GetItemId(int carIndex, int index)
    {
        LoadData();
        return cars.progress[carIndex].Tunning[index];
    }
    public ItemId[] GetAllTuning(int carIndex)
    {
        LoadData();
        return cars.progress[carIndex].Tunning;
    }
    private void DeleteTuning(int carIndex)
    {
        for (int i = 0; i < cars.progress[carIndex].Tunning.Length; i++)
        {
            cars.progress[carIndex].Tunning[i] = 0;
        }
    }
    public (bool isOpen, int moneyCount, string name) UnlockRandomCar(SoCarData[] carsList)
    {
        LoadData();
        int random = Random.Range(0, carsList.Length);
        if (cars.progress[carsList[random].Index].IsOpen) return (false, carsList[random].Price, carsList[random].Name);
        else
        {
            cars.progress[carsList[random].Index].IsOpen = true;
            SaveData();
            return (true, 0, carsList[random].Name);
        }
    }
    public void FillCar(int index)
    {
        LoadData();
        cars.progress[index].Fuel = 10;
        SaveData();
    }
}
