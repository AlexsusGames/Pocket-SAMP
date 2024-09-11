using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOffer : MonoBehaviour
{
    [SerializeField] private SoOffersData offer;
    [SerializeField] private SoResourcesInfo resourcesInfo;
    [Space]
    [SerializeField] private Image component1;
    [SerializeField] private Image component2;
    [SerializeField] private Image offerItem;
    [Space]
    [SerializeField] private InfoTabCaller info;
    private ItemsData itemsData = new ItemsData();
    [SerializeField] private Button button;
    public static Action OnOffering;
    private GetItemInfo itemInfo = new GetItemInfo();

    private void Start()
    {
        SetData();
    }
    private void SetData()
    {
        component1.sprite = resourcesInfo.GetResSprite(offer.itemsForOffer[0]);
        component2.sprite = resourcesInfo.GetResSprite(offer.itemsForOffer[1]);
        offerItem.sprite = resourcesInfo.GetResSprite(offer.ItemId);
        if (itemsData.GetRes(offer.itemsForOffer[0]) > 0 && itemsData.GetRes(offer.itemsForOffer[1]) > 0) button.interactable = true;
        else button.interactable = false;
    }
    public void TakeOffer()
    {
        if (itemsData.GetRes(offer.itemsForOffer[0]) > 0 && itemsData.GetRes(offer.itemsForOffer[1]) > 0)
        {
            itemsData.ChangeRes(offer.ItemId, 1);
            itemsData.ChangeRes(offer.itemsForOffer[0], -1);
            itemsData.ChangeRes(offer.itemsForOffer[1], -1);
            info.CallInfoPanel($"Вы обменяли свои ресурсы на предмет: <color=green>{itemInfo.GetItemName(offer.ItemId)}</color>");
            SetData();
            OnOffering?.Invoke();
        } 
    }
}
