using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaceReward : MonoBehaviour
{
    [SerializeField] private Image rewardImage;
    [SerializeField] private TMP_Text raceResultText;
    [SerializeField] private TMP_Text raceRewardsText;
    [SerializeField] private SoResourcesInfo info;
    private GetItemInfo itemInfo = new GetItemInfo();
    private PersonalStats stats = new PersonalStats();
    private ItemId rewardId;
    private int itemsCount;
    private int respectsCount;
    private Wallet wallet = new Wallet();
    private ItemsData data = new ItemsData();

    private void OnEnable() => StartRaceButton.OnReward += SetReward;
    private void OnDisable() => StartRaceButton.OnReward -= SetReward;
    public void SetData(bool isWin)
    {
        CalculateRewards(isWin);
        if (isWin) stats.ChangeStats(1, stats.RaceWinKey);
        else stats.ChangeStats(1, stats.RaceLostKey);
        rewardImage.sprite = info.GetResSprite(rewardId);
        raceResultText.text = isWin ? "Победа!" : "Поражение!";
        raceResultText.color = isWin ? Color.green : Color.red;
        string result = isWin ? "победу" : "участие";
        raceRewardsText.text = $"Вы получили <color=green>{itemsCount} '{itemInfo.GetItemName(rewardId)}'</color>\nВы получили <color=#7884cd>{respectsCount}</color> очков <color=#7884cd>Уважения</color> за {result} в гонке!";
        GiveRewards();
    }
    private void SetReward(ItemId item, int respectCount)
    {
        rewardId = item;
        respectsCount = respectCount;
    }
    private void GiveRewards()
    {
        wallet.RespectsOperation(respectsCount);
        data.ChangeRes(rewardId, itemsCount);
    }
    private void CalculateRewards(bool isWin)
    {
        respectsCount = isWin ? respectsCount * 3 : respectsCount;
        itemsCount = isWin ? 3 : 1;
    }
}
