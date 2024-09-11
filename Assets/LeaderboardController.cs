using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    [SerializeField] private LeaderboardVisual visual;
    [SerializeField] private GameObject loadingImage;
    [SerializeField] private GameObject loadingText;

    private LeaderboardModel model = new();

    private async void OnEnable()
    {
        try
        {
            await model.CheckPlayerStats();
            var leadersData = await model.GetLeaders();
            var playersData = await model.GetPlayerData();
            visual.SetOthersVisual(leadersData.data, leadersData.names);
            visual.SetPlayerVisual(playersData.data, playersData.name);
            loadingText.SetActive(false);
            loadingImage.SetActive(false);
        }
        catch(Exception e)
        {
            Debug.LogException(e);
            loadingImage.SetActive(false);
            loadingText.SetActive(true);
        }
    }
}
