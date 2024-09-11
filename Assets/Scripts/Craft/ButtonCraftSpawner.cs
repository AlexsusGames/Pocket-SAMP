using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCraftSpawner : MonoBehaviour
{
    [SerializeField] private CallCraftPanel craftPanel;
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private RectTransform content;
    private RectTransform buttonRect;
    private SoCraftData[] crafts;
    private List<SoCraftData> availableCrafts;
    private List<Button> buttons = new List<Button>();
    private void OnEnable()
    {
        buttonRect = buttonPrefab.GetComponent<RectTransform>();
        UpdateInfo();
    } 

    public void UpdateInfo()
    {
        ButtonDisable();
        LoadData();
        SetHeight(availableCrafts.Count);
        Vector2 firstPos = GetPosition();
        for (int i = 0; i < availableCrafts.Count; i++)
        {
            int index = i;
            var button = Instantiate(buttonPrefab, content);
            buttons.Add(button);
            button.TryGetComponent(out RectTransform rect);
            rect.anchoredPosition = firstPos;
            button.TryGetComponent(out CraftButton component);
            component.SetData(availableCrafts[index]);
            button.onClick.AddListener(() => craftPanel.OpenVizual(availableCrafts[index], false, component.GetCount()));
            firstPos = new Vector2(40, firstPos.y - buttonRect.sizeDelta.y);
        }
    }
    private void ButtonDisable()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i] != null)
            Destroy(buttons[i].gameObject);
        }
    }
    private List<SoCraftData> GetAvailableCrafts()
    {
        int workBenchLevel = PlayerPrefs.GetInt("Craft");
        List<SoCraftData> result = new List<SoCraftData>();
        for (int i = 0;i < crafts.Length;i++)
        {
            if (crafts[i].WorkbenchLevel <= workBenchLevel)
            {
                result.Add(crafts[i]);
            }
        }
        return result;
    }
    private void LoadData()
    {
        if (crafts == null)
            crafts = Resources.LoadAll<SoCraftData>("Items");
        availableCrafts = GetAvailableCrafts();
    }
    private void SetHeight(int buttonsCount)
    {
        content.sizeDelta = new Vector2(content.sizeDelta.x, buttonRect.sizeDelta.y * buttonsCount);
        content.anchoredPosition = new Vector2(content.anchoredPosition.x, content.rect.yMin);
    }
    private Vector2 GetPosition()
    {
        float position = -content.rect.yMin - buttonRect.sizeDelta.y / 2;
        Vector2 pos = new Vector2(40, position);
        return pos;
    }
}
