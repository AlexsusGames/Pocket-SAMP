using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftProcess 
{
    private ItemsData ResData = new ItemsData();
    private CharactersBonuses bonus = new CharactersBonuses();
    private TaskLoader task = new();
    private int craftErrorRes;
    private bool isError;

    public (bool success, string msg, int errorType) Craft(SoCraftData data)
    {
        ResData.LoadData();
        for (int i = 0; i < data.ResourcesCount.Count; i++)
        {
            if (ResData.GetRes(data.Resources[i]) >= data.ResourcesCount[i])
            ResData.ChangeRes(data.Resources[i], -data.ResourcesCount[i]);
            else
            {
                craftErrorRes = i;
                isError = true;
                break;
            }
        }
        if (isError)
        {
            for (int i = craftErrorRes - 1; i >= 0; i--)
            {
                ResData.ChangeRes(data.Resources[i], data.ResourcesCount[i]);
            }
            return (false, "Не хватает ресурсов!", 2);
        }
        else
        {
            int craftChance = data.CraftChance;
            craftChance = bonus.IsDoubleChanceCraft() ? craftChance * 2 : craftChance;
            if (craftChance >= Random.Range(1, 101))
            {
                task.ChangeCount(KindOfTask.Crafts);
                return (true, "Крафт прошел успешно!", 0);
            }
            else return (false, "Крафт прошел неудачно!", 1);
        }
    }
}
