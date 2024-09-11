using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskTabVisual : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text infoText;
    [SerializeField] private TMP_Text progressText;

    [SerializeField] private SoResourcesInfo soResourcesInfo;
    private GetItemInfo itemInfo = new();

    private TaskData data;

    private void Awake()
    {
        TaskLoader.OnTaskChanged += SetData;
        TaskLoader.OnProgressChanged += UpdateInfo;
    }
    private void OnDisable()
    {
        TaskLoader.OnTaskChanged -= SetData;
        TaskLoader.OnProgressChanged -= UpdateInfo;
    }
    private void SetData(TaskData task)
    {
        data = task;
        itemImage.sprite = soResourcesInfo.GetResSprite(task.ItemReward);
        infoText.text = $"{GetActionText(task.Kind)} " +
            $"что-бы получить:\n<color=yellow>{task.AzReward} PS-coins\n{itemInfo.GetItemName(task.ItemReward)}</color>";
        progressText.text = $"Прогресс: {task.CurrentProgress} из {task.TaskProgress}";
    }
    private void UpdateInfo(int newAmount)
    {
        progressText.text = $"Прогресс: {newAmount} из {data.TaskProgress}";
    }
    private string GetActionText(KindOfTask kind)
    {
        switch (kind)
        {
            case KindOfTask.Crafts: return $"Сделайте <color=green>{data.TaskProgress}</color> попыток крафта";
            case KindOfTask.Races: return $"Участвуйте в <color=green>{data.TaskProgress}</color> заездах";
            default: return $"Соберите <color=green>{data.TaskProgress} '{itemInfo.GetItemName(data.TaskItem)}'</color>";
        }
    }
}
