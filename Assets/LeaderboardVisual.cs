using System.Collections;
using System.Collections.Generic;
using Unity.Services.Leaderboards.Models;
using UnityEngine;

public class LeaderboardVisual : MonoBehaviour
{
    [SerializeField] private List<LeaderboardPlayerVisual> others = new();
    [SerializeField] private LeaderboardPlayerVisual player;
    public void SetPlayerVisual(LeaderboardEntry data, string name)
    {
        player.gameObject.SetActive(true);
        player.SetData(name, data);
    }
    public void SetOthersVisual(List<LeaderboardEntry> data, List<string> names)
    {
        for (var i = 0; i < data.Count; ++i)
        {
            others[i].gameObject.SetActive(true);
            others[i].SetData(names[i], data[i]);
        }
    }
}
