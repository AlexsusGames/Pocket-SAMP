using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private InventoryPlaceChanger order;
    public int Index;
    private Image image;
    private TMP_Text text;
    private bool isFull;
    private InventoryDataLoader data = new InventoryDataLoader();
    public static Action<Transform,ItemId> CallInfoPanel;

    private void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TMP_Text>();
        text.gameObject.SetActive(false);
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => order.ChangeIndexes(Index,isFull));
        button.onClick.AddListener(() => Debug.Log(data.GetCellData().cells[Index].ItemId)); // debug
        button.onClick.AddListener(() => CallInfoPanel(transform,data.GetCellData().cells[Index].ItemId));
    }
    public void SetData(Sprite sprite, int count)
    {
        image.sprite = sprite;
        if(text != null)
        {
            text.gameObject.SetActive(true);
            text.text = count.ToString();
        }
        isFull = true;
    }
    public bool GetStatus()
    {
        return isFull;
    }
    public void ClearCell(Sprite sprite)
    {
        image.sprite = sprite;
        isFull = false;
        text.gameObject.SetActive(false);
    }

}
