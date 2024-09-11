using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Leaderboards.Models;
using UnityEngine;

public class LeaderboardPlayerVisual : MonoBehaviour
{
    [SerializeField] private TMP_Text playerRang;
    [SerializeField] private TMP_Text playerScore;
    [SerializeField] private TMP_Text playerNameText;

    public void SetData(string playerName, LeaderboardEntry data = null)
    {
        if(data != null)
        {
            playerRang.text = (data.Rank + 1).ToString();
            playerScore.text = data.Score.ToString();
            playerNameText.text = playerName;
        }
        else gameObject.SetActive(false);
    }
}
