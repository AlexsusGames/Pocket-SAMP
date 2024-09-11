using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInventoryCellInfo : MonoBehaviour
{
    private ItemId id;
    [SerializeField] private InventoryInfoTab tab;
    private RectTransform rect;
    private void OnEnable()
    {
        rect = GetComponent<RectTransform>();
        InventoryCell.CallInfoPanel += OpenInfo;
        InventoryPlaceChanger.onChange += HideWithDelay;
    }
    private void OnDisable()
    {
        InventoryCell.CallInfoPanel -= OpenInfo;
        InventoryPlaceChanger.onChange -= HideWithDelay;
    }

    private void OpenInfo(Transform transform, ItemId itemId)
    {
        if(itemId != ItemId.None)
        {
            rect.SetParent(transform, true);
            rect.anchoredPosition = Vector3.zero;
            id = itemId;
        }
    }
    public void OpenInfoTab()
    {
        tab.SetData(id);
    }
    private void HideButton()
    {
        rect.SetParent(null, true);
        rect.anchoredPosition = new Vector3(1111, 0, 0);
    }
    private void HideWithDelay()
    {
        Invoke(nameof(HideButton), 0.01f);
    }
}
