using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class SelectedTuning : MonoBehaviour
{
    [SerializeField] private List<ItemId> items = new List<ItemId>();
    [SerializeField] private int index;
    [SerializeField] private Image image;
    private ItemId itemId;
    private int carIndex;
    private CarDataLoader data = new CarDataLoader();
    public static Action OnChange;
    private ItemsData itemData = new ItemsData();

    private void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(DeleteTuning);
    }

    public void SetData(ItemId tuning, int carId,Sprite sprite)
    {
        carIndex = carId;
        itemId = tuning;
        image.sprite = sprite;
    }
    public bool ChangeTuning(ItemId tuning)
    {
        if (items.Contains(tuning) && data.GetItemId(carIndex,index) == 0)
        {
            data.SetTun(carIndex, index, tuning);
            OnChange?.Invoke();
            return true;
        }
        return false;
    }
    private void DeleteTuning()
    {
        if(itemId > 0 && data.GetItemId(carIndex, index) != 0)
        {
            data.SetTun(carIndex, index, 0);
            itemData.ChangeRes(itemId, 1);
            OnChange?.Invoke();
        }
    }
}
