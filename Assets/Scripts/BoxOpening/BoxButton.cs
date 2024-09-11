using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoxButton : MonoBehaviour
{
    [SerializeField] private Image boxImage;
    [SerializeField] private TMP_Text boxCountText;
    public static Action<ItemId> OnItemClicked;

    public void SetData(Sprite sprite,int count, ItemId box)
    {
        boxImage.sprite = sprite;
        boxCountText.text = count.ToString();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => OnItemClicked?.Invoke(box));
        button.TryGetComponent(out SelectableObject selectableObject);
        button.onClick.AddListener(selectableObject.Select);
    }
}
