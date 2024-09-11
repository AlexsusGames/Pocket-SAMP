using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DonatMenu : MonoBehaviour
{
    [SerializeField] private ConfirmTabView view;
    [SerializeField] private Image ButtonConvert;
    [SerializeField] private Image ButtonCar;
    [SerializeField] private Image ButtonVip;
    [SerializeField] private Image ButtonAd;
    private Wallet wallet = new Wallet();
    private ItemsData itemsData = new ItemsData();
    private VipStatus vip = new VipStatus();

    public void BackToMenu()
    {
        LoadScreen.instance.ShowLoadScreen(0.5f);
        SceneManager.LoadScene(0);
    }

    public void BuyCarButton()
    {
        view.gameObject.SetActive(true); 
        UnityAction action = new UnityAction(BuyCar);
        string info = "Купить <color=green>Ларец со случайной машиной</color> за <color=yellow>2000</color>PS-coins?";
        view.SetData(info,action);
    }
    private void BuyCar()
    {
        if(wallet.GetDonate() >= 2000)
        {
            wallet.DonateOperation(-2000);
            itemsData.ChangeRes(ItemId.RandonCarBox, 1);
        }
        view.gameObject.SetActive(false);
    }
    public void BuyVipButton()
    {
        if (!vip.GetVip())
        {
            view.gameObject.SetActive(true);
            UnityAction action = new UnityAction(BuyVip);
            string info = "Купить <color=green>VIP-статус</color> за <color=yellow>5000</color>PS-coins?";
            view.SetData(info, action);
        }
    }
    private void BuyVip()
    {
        if (wallet.GetDonate() >= 5000)
        {
            wallet.DonateOperation(-5000);
            vip.ButVip();
        }
        view.gameObject.SetActive(false);
    }
    public void GiveRewards()
    {
        wallet.DonateOperation(20);
        view.gameObject.SetActive(false);
    }
}
