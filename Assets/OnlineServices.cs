using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Models;
using System.Threading.Tasks;
using System;
using Unity.Services.Leaderboards.Exceptions;
using Unity.Services.CloudSave;
using Unity.Services.Core;
using Unity.Services.CloudSave.Models.Data.Player;

public class OnlineServices 
{
    private LeaderboardScoresPage scores;

    private const string RespectKey = "Leaderboard";

    public async Task Init()
    {
        try
        {
            await Unity.Services.Core.UnityServices.InitializeAsync();
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
    public async Task<LeaderboardScoresPage> GetScoreAsync()
    {
        try
        {
            scores = await LeaderboardsService.Instance.GetScoresAsync(RespectKey);
            return scores;
        }
        catch(LeaderboardsException ex)
        {
            Debug.LogError(ex);

            return null;
        }
    }

    public async Task UpdatePlayerInfo(int newScore)
    {
        try { await LeaderboardsService.Instance.AddPlayerScoreAsync(RespectKey, newScore); }
        catch(LeaderboardsException ex)
        {
            Debug.LogError(ex);
        }
    }
    public async Task<LeaderboardEntry> GetPlayerScore()
    {
        var entry = await LeaderboardsService.Instance.GetPlayerScoreAsync(RespectKey);
        return entry;
    }
}
