using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    private CarDataLoader carDataLoader = new CarDataLoader();
    [SerializeField] private ChatLog chat;
    public void LoadSceneCM()
    {
        LoadScreen.instance.ShowLoadScreen(0.5f);
        SceneManager.LoadScene(2);
    }
    public void LoadSceneGhetto()
    {
        LoadScreen.instance.ShowLoadScreen(0.5f);
        SceneManager.LoadScene(5);
    }
    public void LoadSceneClothShop()
    {
        LoadScreen.instance.ShowLoadScreen(0.5f);
        PlayerPrefs.SetInt("Location", (int)Locations.ClothShop);
        SceneManager.LoadScene(4);
    }
    public void LoadSceneCasino()
    {
        LoadScreen.instance.ShowLoadScreen(0.5f);
        PlayerPrefs.SetInt("Location", (int)Locations.Casino);
        SceneManager.LoadScene(4);
    }
    public void LoadSceneFastFood()
    {
        LoadScreen.instance.ShowLoadScreen(0.5f);
        PlayerPrefs.SetInt("Location", (int)Locations.FastFood);
        SceneManager.LoadScene(4);
    }
    public void LoadScenePawnShop()
    {
        LoadScreen.instance.ShowLoadScreen(0.5f);
        PlayerPrefs.SetInt("Location", (int)Locations.PawnShop);
        SceneManager.LoadScene(4);
    }
    public void LoadSceneCarMarcet()
    {
        LoadScreen.instance.ShowLoadScreen(0.5f);
        PlayerPrefs.SetInt("Location", (int)Locations.CarMarcet);
        SceneManager.LoadScene(4);
    }
    public void LoadSceneRace()
    {
        if (CheckCarAvailable())
        {
            LoadScreen.instance.ShowLoadScreen(0.5f);
            PlayerPrefs.SetInt("Location", (int)Locations.Race);
            SceneManager.LoadScene(4);
        }
        else chat.AddMesage("<color=yellow>У вас нет машины!");
    }
    private bool CheckCarAvailable()
    {
        CarsProgress cars = carDataLoader.GetCarList();
        for (int i = 0; i < cars.progress.Count; i++)
        {
            if (cars.progress[i].IsOpen) return true;
        }
        return false;
    }

}
public enum Locations
{
    ClothShop = 0,
    Casino = 1,
    FastFood = 2,
    PawnShop = 3,
    CarMarcet = 4,
    Race = 5
}
