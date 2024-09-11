using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HomeMenu : MonoBehaviour
{
    [SerializeField] private Button buttonWorkBench;
    [SerializeField] private Button buttonGarage;
    [SerializeField] private GameObject buttonWorkbenchBlock;
    [SerializeField] private GameObject buttonGarageBlock;
    [SerializeField] private InfoTabCaller info;
    [SerializeField] private Button miningButton;
    private HouseDataLoader houseDataLoader = new HouseDataLoader();
    private Wallet waller = new Wallet();
    private int workbenchCost = 500;
    private int garageCost = 500;

    private void Awake()
    {
        CheckAvailable();
        buttonWorkBench.onClick.AddListener(() => BuyProperty("Craft", true));
        buttonGarage.onClick.AddListener(() => BuyProperty("Garage", false));
        int houseLevel = PlayerPrefs.GetInt("House");
        if(houseLevel > 0)
        {
            buttonWorkBench.gameObject.SetActive(true);
            miningButton.gameObject.SetActive(true);
        }
        if(houseLevel > 5) buttonGarage.gameObject.SetActive(true);
    }
    private void CheckAvailable()
    {
        int houseLevel = PlayerPrefs.GetInt("House");
        int workBenchLevel = PlayerPrefs.GetInt("Craft");
        int garageLevel = PlayerPrefs.GetInt("Garage");
        if (houseLevel > 0 && workBenchLevel == 0) buttonWorkBench.interactable = true;
        else if (houseLevel > 0 && workBenchLevel != 0) buttonWorkbenchBlock.SetActive(true);
        else buttonWorkBench.interactable = false;
        if (houseLevel > 6 && garageLevel == 0) buttonGarage.interactable = true;
        else if (houseLevel > 6 && garageLevel != 0) buttonGarageBlock.SetActive(true);
        else buttonGarage.interactable = false;
    }
   
    private void BuyProperty(string button, bool switcher)
    {
        int houseIndex = PlayerPrefs.GetInt("House");
        if (PlayerPrefs.GetInt(button) == 0)
        {
            if (waller.GetMoney() >= workbenchCost && switcher)
            {
                houseDataLoader.ImproveWorkbench(houseIndex, 1);
                info.CallInfoPanel("Вы разблокировали верстак!");
                waller.MoneyOperation(-workbenchCost);
                CheckAvailable();
            }
            else if (waller.GetMoney() >= garageCost && !switcher)
            {
                houseDataLoader.ImproveGarage(houseIndex, 1);
                info.CallInfoPanel("Вы разблокировали гараж!");
                waller.MoneyOperation(-garageCost);
                CheckAvailable();
            }
            else info.CallInfoPanel($"Для покупки недостаточно денег!");
        }
    }
}
