using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxOpeningVisual : MonoBehaviour
{
    [SerializeField] private List<SlotVisual> slots = new List<SlotVisual>();
    [SerializeField] private GameObject OpeningPanel;
    [SerializeField] private SoResourcesInfo resSprites;
    [SerializeField] private InfoTabCaller info;
    [SerializeField] private Button buttonTurn;
    [SerializeField] private Animator animator;
    [SerializeField] private Sprite mainItemSprite;
    [SerializeField] private GameObject viewBlock;
    [SerializeField] private RectTransform slotLine;
    [SerializeField] private Image fastOpeningButton;
    [SerializeField] private Button closeButton;
    private SoBoxData currentBox;
    private PersonalStats stats = new PersonalStats();
    private AdditionalDropChance chance = new();
    private SoBoxData[] boxes => Resources.LoadAll<SoBoxData>("Box");
    public static Action<bool> OnTurn;
    private bool IsFastOpening;

    private void Awake()
    {
        buttonTurn.onClick.AddListener(TurnSlot);
    }
    private void OnEnable()
    {
        BoxButton.OnItemClicked += SetBox;
        RareBoxDrop.OnWin += ShowInfo;
        SlotBoxData.OnWin += ShowInfo;
        SoBoxData.OnBoxEnd += ClosePanels;
    }
    private void OnDisable()
    {
        BoxButton.OnItemClicked -= SetBox;
        RareBoxDrop.OnWin -= ShowInfo;
        SlotBoxData.OnWin -= ShowInfo;
        SoBoxData.OnBoxEnd -= ClosePanels;
    }

    private void SetBox(ItemId boxId)
    {
        currentBox = FindBox(boxId);
        if(currentBox != null)
        {
            SetData();
            OpenPanels(true);
        }
    }
    private void SetData()
    {
        currentBox.UpdateBoxData();
        for (int i = 0; i < currentBox.slots.Length; i++)
        {
            Sprite sprite = currentBox.slots[i].rarity == SlotRarity.MainDrop ? mainItemSprite : resSprites.GetResSprite(currentBox.slots[i].itemId);
            slots[i].SetData(currentBox.slots[i], sprite);
        }
    }
    private SoBoxData FindBox(ItemId id)
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            if (boxes[i].BoxID == id) return boxes[i];
        }
        return null;
    }
    private void TurnSlot()
    {
        StartCoroutine(IsFastOpening ? FastOpening() : SlowOpening());
        stats.ChangeStats(1, stats.BoxOpenedKey);
        chance.ImproveChance();
    }
    private IEnumerator SlowOpening()
    {
        OnTurn?.Invoke(false);
        buttonTurn.interactable = false;
        SetData();
        slotLine.anchoredPosition = new Vector2(520,0);
        viewBlock.SetActive(false);
        closeButton.interactable = false;
        animator.enabled = true;
        animator.Play("SlotsAnim", 0, 0);
        yield return new WaitForSeconds(UnityEngine.Random.Range(6.5f, 7.5f));
        animator.enabled = false;
        currentBox.GiveRewards();
        yield return new WaitForSeconds(1);
        viewBlock.SetActive(true);
        buttonTurn.interactable = true;
        closeButton.interactable = true;
    }
    private IEnumerator FastOpening()
    {
        OnTurn?.Invoke(false);
        buttonTurn.interactable = false;
        SetData();
        slotLine.anchoredPosition = new Vector2(-507, 0);
        viewBlock.SetActive(false);
        currentBox.GiveRewards();
        yield return new WaitForSeconds(1);
        viewBlock.SetActive(true);
        buttonTurn.interactable = true;
    }
    private void ShowInfo(string name, int count, bool result)
    {
        if (!result) info.CallInfoPanel($"Так-как у вас есть <color=green>{name}</color>, Вы получили <color=green>{count}$!");
        else info.CallInfoPanel($"Вы получили редкий предмет: <color=green>{name}</color>. Поздравляем!");
    }
    private void ShowInfo(string name, int count)
    {
        info.CallInfoPanel($"Вы получили <color=green>{count}шт. {name}</color>!");
    }
    private void OpenPanels(bool value)
    {
        buttonTurn.gameObject.SetActive(value);
    }
    private void ClosePanels()
    {
        OpenPanels(false);
    }
    public void ChangeOpeningSpeed()
    {
        var vip = new VipStatus();
        if (vip.GetVip())
        {
            IsFastOpening = !IsFastOpening;
            fastOpeningButton.gameObject.SetActive(IsFastOpening);
        }
        else info.CallInfoPanel("Для быстрого открытия требуется <color=yellow>VIP</color> статус!");
    }
}
