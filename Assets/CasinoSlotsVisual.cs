using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CasinoSlotsVisual : MonoBehaviour
{
    [SerializeField] private Button turnButton;
    [SerializeField] private RectTransform turnButtonTransform;
    [SerializeField] private List<Image> slots = new();
    [SerializeField] private List<Image> WinableSlots = new();
    [SerializeField] private List<Sprite> sprites = new();
    [SerializeField] private Slider betSlider;
    [SerializeField] private TMP_Text betText;
    [SerializeField] private Button exitButton;
    public event Action OnSlotTurned;
    private WaitForSeconds animTime = new(2.5f);
    private Animator animator;

    private SlotMachineModel slotMachineModel;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        ChangeText(betSlider.minValue);
        betSlider.onValueChanged.AddListener(ChangeText);
    }
    public void Init(SlotMachineModel model)
    {
        slotMachineModel = model;
    }
    private void ChangeText(float value)
    {
        int amount = (int)value;
        betText.text = $"{amount}$";
        if (slotMachineModel != null) slotMachineModel.ChangeBet(amount);
    }
    private void InteractableEnabled(bool value)
    {
        exitButton.interactable = value;
        turnButton.interactable = value;
        betSlider.interactable = value;
    }
    public IEnumerator TurnSlots(List<int> combination)
    {
        InteractableEnabled(false);
        SetSlotsSprites(combination);
        animator.enabled = true;
        animator.SetTrigger("play");
        turnButtonTransform.rotation = new Quaternion(180,0,0,0);
        yield return animTime;
        turnButtonTransform.rotation = new Quaternion(0, 0, 0, 0);
        InteractableEnabled(true);
        OnSlotTurned?.Invoke();
    }

    private void SetSlotsSprites(List<int> currentCombination)
    {
        for (int i = 0; i < WinableSlots.Count; i++)
        {
            WinableSlots[i].sprite = sprites[currentCombination[i]];
        }

        for (int i = 0; i < slots.Count; i++)
        {
            int random = UnityEngine.Random.Range(0, currentCombination.Count);
            slots[i].sprite = sprites[random];
        }
    }
}
