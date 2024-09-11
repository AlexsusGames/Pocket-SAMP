using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskVisual : MonoBehaviour
{
    [SerializeField] private Image item;
    [SerializeField] private TMP_Text countText;
    [SerializeField] private SoResourcesInfo resSprites;
    [SerializeField] private Sprite raceSprite;
    [SerializeField] private Sprite craftSprite;
    private int aimCount;

    private void Awake()
    {
        TaskLoader.OnProgressChanged += UpdateCurrentCount;
        TaskLoader.OnTaskChanged += SetData;
    }
    private void OnDisable()
    {
        TaskLoader.OnProgressChanged -= UpdateCurrentCount;
        TaskLoader.OnTaskChanged -= SetData;
    }
    private void SetData(TaskData task)
    {
        if (task.Kind == KindOfTask.Races) item.sprite = raceSprite;
        else if (task.Kind == KindOfTask.Crafts) item.sprite = craftSprite;
        else item.sprite = item.sprite = resSprites.GetResSprite(task.TaskItem);
        aimCount = task.TaskProgress;
        countText.text = $"{task.CurrentProgress}/{aimCount}";
    }
    private void UpdateCurrentCount(int value)
    {
        countText.text = $"{value}/{aimCount}";
    }
}
