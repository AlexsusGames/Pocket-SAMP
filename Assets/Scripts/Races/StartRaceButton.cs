using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartRaceButton : MonoBehaviour
{
    [SerializeField] private int needRespects;
    [SerializeField][Range(-4,8)] private int difficultsIndex;
    [SerializeField][Range(200,400)] private int carSpeadRange;
    [SerializeField] private RaceManager raceManager;
    [SerializeField] private InfoTabCaller info;
    [SerializeField] private GameObject PrepareTab;
    private Wallet wallet = new Wallet();
    [Space]
    [SerializeField] private ItemId itemReward;
    [SerializeField] private int respectsReward;
    [SerializeField] private TMP_Text itemRewardText;
    [SerializeField] private TMP_Text needRespectsRewardText;
    public static Action<ItemId, int> OnReward;
    private GetItemInfo itemInfo = new GetItemInfo();

    private void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => StartRace(carSpeadRange,difficultsIndex));
        itemRewardText.text = $"Приз за участие: \n<color=green>{itemInfo.GetItemName(itemReward)}";
        needRespectsRewardText.text = $"Нужно <color=#7884cd>о.у</color> - <color=#7884cd>{needRespects}";
    }
    private void StartRace(int range, int difficult)
    {
        CarDataLoader data = new();
        int carIndex = PlayerPrefs.GetInt("PlayerCar");
        var playerCar = data.GetCarData(carIndex);
        var playerSoCar = data.GetSoCar(carIndex);
        int speadDiapason = carSpeadRange - 30;
        if (playerSoCar.Speed >= speadDiapason)
        {
            if (playerCar.Fuel > 1)
            {
                if (wallet.GetRespects() >= needRespects)
                {
                    raceManager.StartRace(range, difficult);
                    PrepareTab.SetActive(false);
                    OnReward?.Invoke(itemReward, respectsReward);
                    playerCar.Fuel -= 2;
                    data.SaveData();
                }
                else info.CallInfoPanel("Недостаточно очков <color=#7884cd>Уважения</color> чтобы участвовать в этом заезде!");
            }
            else info.CallInfoPanel("Нет бензина!");
        }
        else info.CallInfoPanel($"Для этого заезда требуется машина быстрее! (<color=green>{speadDiapason}км.ч+</color>)");
    }
}
