using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HousesManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> housesSprites;
    [SerializeField] private Image houseImage;
    [SerializeField] private List<Sprite> starsSprites;
    [SerializeField] private Image starsImage;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text actionText;
    [SerializeField] private Image ramka;
    [SerializeField] private Image buttonImage;
    [SerializeField] private Image[] properties;
    [SerializeField] private TMP_Text[] availability;
    [Space]
    [SerializeField] private List<Image> housesIcons;
    [SerializeField] private Sprite ownImage;
    private HouseDataLoader data = new HouseDataLoader();
    private HousesData progress = new HousesData();
    private Wallet wallet = new Wallet();
    private int index;

    private void Awake()
    {
        progress = data.GetHouseData();
        UpdateIcons();
    }
    public void SetData(int index)
    {
        progress = data.GetHouseData();
        houseImage.sprite = housesSprites[index];
        starsImage.sprite = starsSprites[progress.Houses[index].StarsIndex];
        actionText.text = progress.Houses[index].IsOpen ? "Выбрать" : "Купить";
        ramka.gameObject.SetActive(!progress.Houses[index].IsOpen);
        if (index == PlayerPrefs.GetInt("House"))
        {
            actionText.text = "Выбрано";
            buttonImage.color = Color.yellow;
            PlayerPrefs.SetInt("Craft", progress.Houses[index].WorkbenchLevel);
            PlayerPrefs.SetInt("Garage", progress.Houses[index].GarageLevel);
        }
        else buttonImage.color = Color.green;
        priceText.text = progress.Houses[index].IsOpen ? "" : $"{progress.Houses[index].Price}$";
        this.index = index;
        ShowHouseInfo();
        ShowProperty(progress.Houses[index].IsOpen);
    }
    public void BuyHouse()
    {
        if (progress.Houses[index].IsOpen)
        {
            PlayerPrefs.SetInt("House", index);
            SetData(index);
        }
        else if (!progress.Houses[index].IsOpen && wallet.GetMoney() >= progress.Houses[index].Price)
        {
            data.OpenHouse(index, true);
            wallet.MoneyOperation(-progress.Houses[index].Price);
            SetData(index);
        }
        UpdateIcons();
    }
    private void ShowHouseInfo()
    {              
        properties[0].gameObject.SetActive(true); 
        if (progress.Houses[index].StarsIndex > 1)
        {
            properties[1].gameObject.SetActive(true);
        }
        else properties[1].gameObject.SetActive(false);
    }
    private void ShowProperty(bool value)
    {
        if (value)
        {
            availability[0].text = $"Уровень верстака в доме - {progress.Houses[index].WorkbenchLevel}";
            availability[1].text = $"Уровень гаража в доме - {progress.Houses[index].GarageLevel}";
        }
        else
        {
            availability[0].text = "";
            availability[1].text = "";
        }
    }
    private void UpdateIcons()
    {
        for (int i = 0; i < housesIcons.Count; i++)
        {
            if (progress.Houses[i + 1].IsOpen)
            {
                housesIcons[i].sprite = ownImage;
            }
        }
    }
}
