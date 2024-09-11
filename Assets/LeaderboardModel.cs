using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Leaderboards.Models;
using Unity.VisualScripting;
using UnityEngine;

public class LeaderboardModel 
{
    private int leadersCount = 5;

    private OnlineServices services;
    private LeaderboardNamesData namesData = new();
    private Wallet wallet = new();

    public LeaderboardModel()
    {
        services = GlobalServices.instance;
    }

    public async Task<(List<LeaderboardEntry> data,List<string> names)> GetLeaders()
    {
        var playerData = await GetPlayerData();
        var leadersData = await services.GetScoreAsync();
        List<LeaderboardEntry> datas = new();
        List<string> names = new();
        for (int i = 0; i < leadersData.Results.Count; i++)
        {
            datas.Add(leadersData.Results[i]);
            names.Add(namesData.AddName(leadersData.Results[i].PlayerName));
        }
        if(playerData.data.Rank < leadersCount)
        {
            datas[playerData.data.Rank] = playerData.data;
            names[playerData.data.Rank] = playerData.name;
        }
        return (datas, names);
    }
    public async Task<(LeaderboardEntry data,string name)> GetPlayerData()
    {
        var player = await services.GetPlayerScore();
        string name = PlayerPrefs.GetString("NickName");
        return (player, name);
    }
    public async Task CheckPlayerStats()
    {
        await services.UpdatePlayerInfo(0);
        var currentData = await GetPlayerData();
        int currentScore = (int)currentData.data.Score;
        if(currentScore != wallet.GetRespects())
        {
            int result = wallet.GetRespects() - currentScore;

            await services.UpdatePlayerInfo(result);
        }
    }
}
