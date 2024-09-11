using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OpenBoxTabManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private RectTransform content;
    [SerializeField] private SoResourcesInfo resSprites;
    [SerializeField] private UnityEvent OnBoxEnd;
    private RectTransform buttonRect;
    private ItemsData data = new ItemsData();
    private ItemId[] boxes = { ItemId.Cloth, ItemId.EliteCloth, ItemId.BoxSimpleCar, ItemId.BoxWithBonus, ItemId.BoxSuperCar, ItemId.BoxLuxury, ItemId.ToolBox,ItemId.RandonCarBox, ItemId.BestCarsBox};
    private List<GameObject> buttonsList = new List<GameObject>();
    private int buttonsCount;
    public float offsetX;

    private void Awake()
    {
        buttonRect = buttonPrefab.GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        SoBoxData.OnRewarding += UpdadeInfo;
        BoxOpeningVisual.OnTurn += ButtonEnable;
        UpdadeInfo();
    }
    private void OnDisable()
    {
        SoBoxData.OnRewarding -= UpdadeInfo;
        BoxOpeningVisual.OnTurn -= ButtonEnable;
    }
    private void GetButtonCount()
    {
        buttonsCount = 0;
        for (int i = 0; i < boxes.Length; i++)
        {
            if (data.GetRes(boxes[i]) > 0) buttonsCount++;
        }
    }
    private float GetFirstPosition()
    {
        float position = -content.rect.xMax / 2 + buttonRect.sizeDelta.x / 2;
        return position;
    }
    private void UpdadeInfo()
    {
        GetButtonCount();
        DeleteUnused();
        content.sizeDelta = new Vector2(buttonRect.sizeDelta.x * buttonsCount + offsetX, 0);
        float offset = 0;
        for (int i = 0; i < boxes.Length; i++)
        {
            if (data.GetRes(boxes[i]) > 0)
            {
                var obj = Instantiate(buttonPrefab, content);
                buttonsList.Add(obj);
                obj.TryGetComponent(out RectTransform pos);
                obj.TryGetComponent(out BoxButton box);
                pos.anchoredPosition = new Vector2(GetFirstPosition() + offset, 0);
                box.SetData(resSprites.GetResSprite(boxes[i]), data.GetRes(boxes[i]), boxes[i]);
                offset += buttonRect.sizeDelta.x;
            }
        }
    }
    private void DeleteUnused()
    {
        for (int i = 0; i < buttonsList.Count; i++)
        {
            Destroy(buttonsList[i]);
        }
        buttonsList.Clear();
    }
    private void ButtonEnable(bool value)
    {
        for (int i = 0; i < buttonsList.Count; i++)
        {
            buttonsList[i].TryGetComponent(out Button button);
            button.interactable = value;
        }
    }
}
