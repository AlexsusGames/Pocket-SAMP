using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OwnTuningManager : MonoBehaviour
{
    [SerializeField] private List<Image> tunImages = new List<Image>();
    [SerializeField] private SoResourcesInfo info;
    [SerializeField] private List<SelectedTuning> selectedTunings = new List<SelectedTuning>();
    [SerializeField] private GameObject carDescribtion;
    private ItemsData ItemsData = new ItemsData();
    private const int TuningCount = 12;
    private List<TuningCell> tuningCells = new List<TuningCell>();

    private void OnEnable()
    {
        UpdateInfo();
        SelectedTuning.OnChange += UpdateWithDelay;
    }
    private void OnDisable()
    {
        SelectedTuning.OnChange -= UpdateWithDelay;
    }
    private void Start()
    {
        if (!carDescribtion.activeInHierarchy)
        {
            for (int i = 0; i < tuningCells.Count; i++)
            {
                tuningCells[i].TryGetComponent(out Button button);
                button.interactable = false;
            }
        }
    }
    private void UpdateInfo()
    {
        ClearCells();
        int index = (int)ItemId.KolenvalImprove;
        int cellIndex = 0;
        for (int i = 0; i < TuningCount; i++)
        {
            if (ItemsData.GetRes((ItemId)index) > 0)
            {
                Transform parent = tunImages[cellIndex].transform.parent;
                parent.gameObject.SetActive(true);
                parent.TryGetComponent(out TuningCell cell);
                tuningCells.Add(cell);
                cell.Tuning = (ItemId)index;
                tunImages[cellIndex].sprite = info.GetResSprite((ItemId)index);
                cellIndex++;
            }
            index++;
        }
        SetTuningEvents();
    }
    private void SetTuningEvents()
    {
        for (int i = 0; i < tuningCells.Count; i++)
        {
            int index = i;
            tuningCells[index].TryGetComponent(out Button button);
            button.onClick.AddListener(() => SetTuning(tuningCells[index].Tuning));
        }
    }
    private void SetTuning(ItemId id)
    {
        for (int i = 0; i < selectedTunings.Count; i++)
        {
            if (selectedTunings[i].ChangeTuning(id) && ItemsData.GetRes(id) > 0)
            {
                ItemsData.ChangeRes(id, -1);
            }
        }
    }
    private void ClearCells()
    {
        for (int i = 0; i < tuningCells.Count; i++)
        {
            tuningCells[i].gameObject.SetActive(false);
        }
        tuningCells.Clear();
    }
    private void UpdateWithDelay()
    {
        Invoke(nameof(UpdateInfo), 0.01f);
    }
}
