using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCrafting : MonoBehaviour
{
    [SerializeField] private InfoTabCaller info;
    [SerializeField] private InfoLineCaller infoLine;
    [SerializeField] private Button exitButton;
    private CraftProcess process = new CraftProcess();
    private ItemsData resData = new ItemsData();
    private PersonalStats stats = new PersonalStats();
    private ItemId craftItem;

    public void ItemCrafting(SoCraftData data)
    {
        exitButton.interactable = true;
        craftItem = data.CraftItem;
        var result = process.Craft(data);
        if (result.success)
        {
            resData.ChangeRes(craftItem, 1);
            info.CallInfoPanel(result.msg);
            infoLine.CallInfoLine("Successfully", true);
            stats.ChangeStats(1, stats.SuccessfulCraftsKey);
        }
        else
        {
            info.CallInfoPanel(result.msg);
            if(result.errorType == 1)
            infoLine.CallInfoLine("Failing", false);
            stats.ChangeStats(1, stats.UnSuccessfulCraftsKey);
        }
    } 
}