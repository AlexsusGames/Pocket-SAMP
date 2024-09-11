using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccessoriesForQuests : MonoBehaviour
{
    [SerializeField] private List<SoAccessory> list = new List<SoAccessory>();
    [SerializeField] private List<AccessoryButtonVisual> visuals = new List<AccessoryButtonVisual>();
    [SerializeField] private List<TMP_Text> textPrices = new List<TMP_Text>();
    [SerializeField] private Image progressImage;
    [SerializeField] private TMP_Text progressText;
    private GhettoStatsData data = new();
    private PersonalStats stats = new();
    private int completedTasks => stats.GetStats(stats.TaskComplated);

    private void OnEnable()
    {
        SetData();
    }
    private void SetData()
    {
        int count = completedTasks;
        for(int i = 0; i < list.Count; i++)
        {
            int needCount = (i + 1) * 10;
            textPrices[i].text = needCount.ToString();
            visuals[i].SetData(list[i]);
            if (count >= needCount)
            {
                if (!data.IsContains(list[i]))
                data.AddNewAccessory(list[i]);
            }
            else visuals[i].SetUnlockSprite();
        }
        float result = list.Count * 10f;
        if(count != 0)
        {
            progressImage.fillAmount = count / result;
            progressText.text = count.ToString();
        }
    }
}
