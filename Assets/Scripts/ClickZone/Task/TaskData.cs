using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaskData 
{
    public KindOfTask Kind;
    public ItemId TaskItem;
    public int TaskProgress;
    public int CurrentProgress;
    public ItemId ItemReward;
    public int AzReward;
}
