using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class TaskLoader 
{
    private const string Key = "TaskKey";
    public static Action<TaskData> OnTaskChanged;
    public static Action<int> OnProgressChanged;
    public static Action OnRewards;
    private TaskData task;
    private TaskBuilder taskBuilder = new();
    private ItemsData items = new();
    private Wallet wallet = new();
    private PersonalStats stats = new();
    
    private void SaveTask(TaskData task)
    {
        string save = JsonUtility.ToJson(task);
        PlayerPrefs.SetString(Key, save);
        PlayerPrefs.Save();
    }

    public TaskData GetTask()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            string save = PlayerPrefs.GetString(Key);
            task = JsonUtility.FromJson<TaskData>(save);
            OnTaskChanged?.Invoke(task);
            return task;
        }
        else
        {
            task = GetNewTask();
            return task;
        };
    }
    private TaskData GetNewTask()
    {
        task = taskBuilder.GetTask();
        OnTaskChanged?.Invoke(task);
        SaveTask(task);

        return task;
    }
    public void DeleteCurrentTask()
    {
        task = GetNewTask();
    }
    public void ChangeCount(int count, ItemId item)
    {
        if (task == null) GetTask();
        if (task.Kind == KindOfTask.Resources)
        {
            if (item == task.TaskItem)
            {
                task.CurrentProgress += count;
                OnProgressChanged?.Invoke(task.CurrentProgress);
                SaveTask(task);
                if (task.CurrentProgress >= task.TaskProgress) GiveRewards();
            }
        }
    }
    public void ChangeCount(KindOfTask kind)
    {
        if(task == null) GetTask();
        if (task.Kind == kind)
        {
            task.CurrentProgress++;
            SaveTask(task);
            if (task.CurrentProgress >= task.TaskProgress) GiveRewards();
        }
    }
    private void GiveRewards()
    {
        items.ChangeRes(task.ItemReward, 1);
        wallet.DonateOperation(task.AzReward);
        stats.ChangeStats(1, stats.TaskComplated);
        OnRewards?.Invoke();
        DeleteCurrentTask();
    }
}
public enum KindOfTask
{
    Resources,
    Crafts,
    Races
}
