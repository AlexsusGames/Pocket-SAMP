using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryInfoTab : MonoBehaviour
{
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemInfo;
    [SerializeField] private Button buttonUse;
    [SerializeField] private GameObject tablo;
    public static Action OnShowingInfo;
    [Space]
    [SerializeField] private UnityEvent sellRes;
    [SerializeField] private UnityEvent sellItem;
    private GetItemInfo getInfo = new GetItemInfo();

    public void SetData(ItemId itemId)
    {
        OnShowingInfo?.Invoke();
        tablo.SetActive(true); 
        itemName.text = GetItemName((int)itemId);
        SetEvent(itemId);
        itemInfo.text = getInfo.GetItemDescription(itemId);
    }
    private string GetItemName(int index)
    {
        return getInfo.GetItemName((ItemId)index);
    }
    private void SetEvent(ItemId id)
    {
        if(id <= ItemId.Aluminum)
        {
            buttonUse.onClick.AddListener(SellRes);
        }
        else
        {
            buttonUse.onClick.AddListener(SellItem);
        }
    }
    private void SellRes()
    {
        sellRes.Invoke();
    }
    private void SellItem()
    {
        sellItem.Invoke();
    }
}
