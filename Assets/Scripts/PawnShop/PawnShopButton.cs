using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PawnShopButton : MonoBehaviour
{
    [SerializeField] private Image item;
    [SerializeField] private SoResourcesInfo itemInfo;
    public static Action<ItemId> OnClick;
    private ItemId itemId;
    public void SetData(ItemId id)
    {
        itemId = id;
        item.sprite = itemInfo.GetResSprite(id);
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OpenSellMenu);
    }
    private void OpenSellMenu()
    {
        OnClick?.Invoke(itemId);
    }
}
