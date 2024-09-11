using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;

public class Mining : MonoBehaviour
{
    [SerializeField] private MiningVisual visual;
    [SerializeField] private VideocardImprovingPanel improvingPanel;
    [SerializeField] private InfoTabCaller info;
    private MiningController controller = new();
    private HouseDataLoader houseLoader = new();
    private Wallet wallet = new();
    private MiningChanger changer;
    private HouseProgress data;

    private ItemsData itemsData = new ItemsData();

    private void OnEnable()
    {
        data = houseLoader.GetHouseData().Houses[PlayerPrefs.GetInt("House")];
        visual.SetData(data.Mining);
        changer = new MiningChanger(data.Mining);
        controller.Subscribe(visual, changer);
    }
    private void OnDisable() => controller.Unsubscribe(visual, changer);
    private void ImproveVideocard(int index)
    {
        if (data.Mining.Videocards[index].Level < 10)
        {
            int chance = data.Mining.Videocards[index].Level * 10;
            if (itemsData.GetRes(ItemId.Lubricant) > 1)
            {
                if (Random.Range(1, 101) > chance)
                {
                    changer.ImproveVideocard(index);
                    info.CallInfoPanel("Попытка улучшения прошло успешно!");
                    houseLoader.SaveData();
                }
                else
                {
                    info.CallInfoPanel("Попытка улучшения прошло неудачно!");
                }
                itemsData.ChangeRes(ItemId.Lubricant, -2);
            }
            else info.CallInfoPanel($"Недостаточно ресурсов для улучшения");
        }
        else info.CallInfoPanel("Видеокарта максимального уровня!");
    }
    public void ServiceVideocard()
    {
        if (itemsData.GetRes(ItemId.Cooling) > 0)
        {
            if (changer.ServiceVideocard())
            {
                itemsData.ChangeRes(ItemId.Cooling, -1);
                houseLoader.SaveData();
                info.CallInfoPanel("Видеокарта обслужена");
            }
            else info.CallInfoPanel("Видеокарты в обслуживании не нуждаются!");
        }
        else info.CallInfoPanel("Нужен предмет 'Охлаждающая жидкость'!");
    }
    public void SetVideocard()
    {
        if (itemsData.GetRes(ItemId.Videocard) > 0)
        {
            if (changer.SetVideocard())
            {
                itemsData.ChangeRes(ItemId.Videocard, -1);
                houseLoader.SaveData();
                info.CallInfoPanel("Видеокарта установлена");
            }
            else info.CallInfoPanel("В этом доме максимальное количество видеокарт");
        }
        else info.CallInfoPanel("У вас нет видеокарт!");
    }
    public void OpenImprovrPanel(int index)
    {
        UnityAction action = new UnityAction(() => ImproveVideocard(index));
        improvingPanel.OpenPanel(data.Mining.Videocards[index],action);
    }
    public void WithdrowAz()
    {
        int amount = changer.WithdrowAz();
        wallet.DonateOperation(amount);
        houseLoader.SaveData();
        if (amount > 0)
        {
            info.CallInfoPanel($"Добавлено <color=yellow>{amount} PS-coins");
        }
    }
}
