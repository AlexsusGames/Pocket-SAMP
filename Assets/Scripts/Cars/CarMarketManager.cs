using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CarMarketManager : MonoBehaviour
{
    [SerializeField] private Image carImage;
    [SerializeField] private TMP_Text carName;
    [SerializeField] private TMP_Text carSpead;
    [SerializeField] private TMP_Text carAcceleration;
    [SerializeField] private TMP_Text carPrice;
    [Space]
    [SerializeField] private Button callPanelButton;
    [SerializeField] private Button buyButton;
    [SerializeField] private TMP_Text buttonAction;
    [SerializeField] private Color buyColor;
    [SerializeField] private Color sellColor;
    [SerializeField] private InfoTabCaller info;
    [SerializeField] private CarAcceptWindow accept;
    private int price;
    private int index;
    private int carIndex;
    private SoCarData[] cars;
    private CarDataLoader carData = new CarDataLoader();
    private Wallet wallet = new Wallet();
    private List<bool> carsList = new List<bool>();

    private void Awake()
    {
        cars = Resources.LoadAll<SoCarData>("Cars/CarsMarket");
        SetData(cars[index]);
    }

    private void SetData(SoCarData data)
    {
        UpdateList();
        price = data.Price;
        carIndex = data.Index;
        carImage.sprite = data.SideSprite;
        carSpead.text = $"{data.Speed}км.ч";
        carAcceleration.text = $"{data.Acceleration}сек";
        carName.text = data.Name;
        buyButton.onClick.RemoveAllListeners();
        if (carsList[carIndex])
        {
            buyButton.onClick.AddListener(SellCar);
            carPrice.text = $"{price / 2}$";
            callPanelButton.image.color = sellColor;
            buttonAction.text = "Продать";
        }
        else
        {
            buyButton.onClick.AddListener(BuyCar);
            carPrice.text = $"{price}$";
            callPanelButton.image.color = buyColor;
            buttonAction.text = "Купить";
        }
        callPanelButton.onClick.AddListener(CallAcceptPanel);
        
    }
    private void BuyCar()
    {
        if (wallet.GetMoney() >= price && !carsList[carIndex])
        {
            wallet.MoneyOperation(-price);
            carData.UnlockCar(carIndex, true);
            SetData(cars[index]);
            info.CallInfoPanel($"Вы купили машину <color=green>{carName.text}</color>!");
        }
        else info.CallInfoPanel("Не хватает денег!");
    }
    private void SellCar()
    {
        if (carsList[carIndex])
        {
            wallet.MoneyOperation(price / 2);
            carData.UnlockCar(carIndex,false);
            SetData(cars[index]);
            info.CallInfoPanel($"Вы продали машину <color=green>{carName.text}</color>!");
        }
    }
    public void ChangeCar(int value)
    {
        index += value;
        if (index < 0) index = cars.Length - 1;
        else if (index > cars.Length - 1) index = 0;
        SetData(cars[index]);
    }
    private void UpdateList()
    {
        carsList.Clear();
        List<CarProgress> list = carData.GetCarList().progress;
        for (int i = 0; i < list.Count; i++)
        {
            carsList.Add(list[i].IsOpen);
        }
    }
    private void CallAcceptPanel()
    {
        string info = carsList[carIndex] ? $"Продать <color=green>{carName.text}</color> за <color=green>{carPrice.text}</color>?" : $"Купить <color=green>{carName.text}</color> за <color=green>{carPrice.text}</color>?";
        accept.SetData(carName.text, info, buttonAction.text);
    }
}
