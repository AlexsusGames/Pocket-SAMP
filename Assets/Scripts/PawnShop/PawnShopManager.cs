using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PawnShopManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private RectTransform content;
    [SerializeField] private PawnShopSellMenu menu;
    private RectTransform buttonRect;
    private List<ItemId> itemsId = new List<ItemId>();
    private ItemsData data = new ItemsData();
    private List<PawnShopButton> buttons = new List<PawnShopButton>();
    public float OffsetX;
    private float buttonSizeOffset = 20;
    private void Awake()
    {
        buttonRect = buttonPrefab.GetComponent<RectTransform>();
        CreateList();
        UpdateInfo();
    }
    private void OnEnable()
    {
        PawnShopSellMenu.OnSell += UpdateInfo;
        ItemOffer.OnOffering += UpdateInfo;
        PawnShopButton.OnClick += OpenSellMenu;
    } 
    private void OnDisable()
    {
        PawnShopSellMenu.OnSell -= UpdateInfo;
        ItemOffer.OnOffering -= UpdateInfo;
        PawnShopButton.OnClick -= OpenSellMenu;
    }
    private void UpdateInfo()
    {
        SetContentSize();
        DissableButtons();
        Vector2 pos = new Vector2(GetFirstPosition(), 0);
        for (int i = 0; i < itemsId.Count; i++)
        {
            if (data.GetRes(itemsId[i]) > 0)
            {
                var obj = Instantiate(buttonPrefab,content);
                obj.TryGetComponent(out Button button);
                obj.TryGetComponent(out SelectableObject selectableObject);
                obj.TryGetComponent(out RectTransform rectPosition);
                obj.TryGetComponent(out PawnShopButton pawnshop);
                buttons.Add(pawnshop);
                rectPosition.anchoredPosition = pos;
                pawnshop.SetData(itemsId[i]);
                button.onClick.AddListener(() => selectableObject.Select());
                pos = new Vector2(pos.x + rectPosition.sizeDelta.x + buttonSizeOffset, pos.y);
            }
        }
    }
    private float GetFirstPosition()
    {
        float position = -content.rect.xMax + buttonRect.sizeDelta.x / 2 + buttonSizeOffset;
        return position;
    }
    private void SetContentSize()
    {
        float result = buttonRect.sizeDelta.x + buttonSizeOffset;
        content.sizeDelta = new Vector2(result * GetButtonsCount() + buttonSizeOffset, content.sizeDelta.y);
    }
    private int GetButtonsCount()
    {
        int count = 0;
        for (int i = 0; i < itemsId.Count; i++)
        {
            if (data.GetRes(itemsId[i]) > 0)
            {
                count++;
            }
        }
        return count;
    }
    private void DissableButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i] != null) 
            Destroy(buttons[i].gameObject);
        }
    }
    private void CreateList()
    {
        int Index = (int)ItemId.Cloth;
        List<int> list = data.GetItemList();
        for (int i = Index; i < list.Count; i++)
        {
            itemsId.Add((ItemId)i);
        }
    }
    private void OpenSellMenu(ItemId id)
    {
        menu.gameObject.SetActive(true);
        menu.SetData(id);
    }
}
