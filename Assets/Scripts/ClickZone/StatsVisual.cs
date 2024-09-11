using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsVisual : MonoBehaviour
{
    [SerializeField] private SoResourcesInfo HomeSprites;
    [SerializeField] private SoResourcesInfo AvatarSprites;
    [SerializeField] private SoResourcesInfo CarsSprites;
    [Space]
    [SerializeField] private Image homeImage;
    [SerializeField] private Image avatarImage;
    [SerializeField] private Image carImage;
    [SerializeField] private GameObject vipImage;
    private CarDataLoader carData = new CarDataLoader();
    private PersonalStats stats = new PersonalStats();
    private readonly ProfitCalculater bank = new ProfitCalculater();
    [Space]
    [SerializeField] private TMP_Text nickName;
    [SerializeField] private TMP_Text moneyEarned;
    [SerializeField] private TMP_Text itemsSold;
    [SerializeField] private TMP_Text casinoMoneyWin;
    [SerializeField] private TMP_Text casinoMoneyLost;
    [SerializeField] private TMP_Text raceWin;
    [SerializeField] private TMP_Text raceLost;
    [SerializeField] private TMP_Text successfulCrafts;
    [SerializeField] private TMP_Text unsuccessfulCrafts;
    [SerializeField] private TMP_Text boxOpened;
    [SerializeField] private TMP_Text currentProfit;
    [SerializeField] private TMP_Text timePlayed;


    private void OnEnable()
    {
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        nickName.text = $"Имя: <color=yellow>{PlayerPrefs.GetString("NickName")}";
        homeImage.sprite = HomeSprites.GetResSprite((ItemId)PlayerPrefs.GetInt("House"));
        avatarImage.sprite = AvatarSprites.GetResSprite((ItemId)PlayerPrefs.GetInt("Avatar"));
        if(PlayerPrefs.HasKey("PlayerCar") && carData.GetCarList().progress[PlayerPrefs.GetInt("PlayerCar")].IsOpen)
        carImage.sprite = CarsSprites.GetResSprite((ItemId)PlayerPrefs.GetInt("PlayerCar"));
        else carImage.gameObject.SetActive(false);
        VipStatus status = new VipStatus();
        vipImage.SetActive(status.GetVip());
        UpdateStats();
    }
    private void UpdateStats()
    {
        moneyEarned.text = $"Заработано в ломбарде: <color=green>{stats.GetStats(stats.MoneyEarnedKey)}$";
        itemsSold.text = $"Предметов продано: <color=green>{stats.GetStats(stats.ItemsSoldKey)}";
        casinoMoneyWin.text =  $"В казино выиграно: <color=green>{stats.GetStats(stats.CasinoWinKey)}$";
        casinoMoneyLost.text = $"В казино проиграно: <color=red>{stats.GetStats(stats.CasinoLostKey)}$";
        raceWin.text = $"Заездов выиграно: <color=green>{stats.GetStats(stats.RaceWinKey)}";
        raceLost.text = $"Заездов проиграно: <color=red>{stats.GetStats(stats.RaceLostKey)}";
        successfulCrafts.text = $"Успешных крафтов: <color=green>{stats.GetStats(stats.SuccessfulCraftsKey)}";
        unsuccessfulCrafts.text = $"Неудачных крафтов: <color=red>{stats.GetStats(stats.UnSuccessfulCraftsKey)}";
        boxOpened.text = $"Боксов открыто: <color=green>{stats.GetStats(stats.BoxOpenedKey)}";
        currentProfit.text = $"Прибыль в PayDay: <color=green>{bank.GetProfit()}$";
        timePlayed.text = $"Вы играли: <color=green>{stats.GetStats(stats.TimePlayed)}</color> минут.";
    }
}
