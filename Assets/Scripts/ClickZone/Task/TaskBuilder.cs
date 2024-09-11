using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskBuilder 
{
    private TaskData task = new TaskData();
    private ItemsValue items = new ItemsValue();
    private PersonalStats personalStats = new PersonalStats();
    public TaskData GetTask()
    {
        task.Kind = GetKind();
        task.TaskProgress = GetCount(task.Kind);
        task.TaskItem = GetItem(task.Kind);
        task.ItemReward = GetItemReward(task.Kind,task.TaskProgress);
        task.AzReward = GetAzReward(task.Kind,task.TaskProgress);
        task.CurrentProgress = 0;
        return task;
    }
    private ItemId GetItemReward(KindOfTask kind,int count)
    {
        if (kind == KindOfTask.Resources)
        {
            if (count < 100) return ItemId.Cloth;
            if (count < 200) return ItemId.EliteCloth;
            if (count < 300) return ItemId.ToolBox;
            if (count < 400) return ItemId.BoxLuxury;
            else return ItemId.BestCarsBox;
        }
        if (kind == KindOfTask.Races) return items.GetItem(items.TuningItems);
        else return items.GetItem(items.CraftItems);
    }
    private KindOfTask GetKind()
    { 
        int random = Random.Range(0, 100);
        if (random > 80 && random < 90)
        {
            if (GetPlayerProgress() > 0) return KindOfTask.Crafts;
        }
        else if(random >= 90) return KindOfTask.Races;
        return KindOfTask.Resources;
    }
    private int GetAzReward(KindOfTask kind, int count)
    {
        if(kind == KindOfTask.Resources)
        {
            int result = count / 100;
            return result + 1;
        }
        else return count;
    }
    private ItemId GetItem(KindOfTask kind)
    {
        if (personalStats.GetStats(personalStats.TaskComplated) < 3 && PlayerPrefs.GetInt("House") == 0)
        {
            return (ItemId)Random.Range(0, 2);
        }
        if (kind == KindOfTask.Resources)
        {
            var item = items.GetItem(GetPlayerProgress() == 2 ? items.RareAndUsualResources : items.UsualResourse);
            if (item == ItemId.Silver) item = ItemId.Stone;
            return item;
        }
        else return ItemId.None;
    }
    private int GetCount(KindOfTask kind)
    {
        switch (kind)
        {
            case KindOfTask.Resources: return Random.Range(5, 51) * 10;
            case KindOfTask.Crafts: return Random.Range(5, 10);
            case KindOfTask.Races: return Random.Range(5, 10);
            default: return 0;
        }
    }
    private int GetPlayerProgress()
    {
        int progress = 0;
        if(PlayerPrefs.GetInt("House") > 0) progress++;
        if(PlayerPrefs.GetInt("PlayerCar") > 0)progress++;
        return progress;
    }
}
