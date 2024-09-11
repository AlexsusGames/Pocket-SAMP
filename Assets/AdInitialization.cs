using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdInitialization : MonoBehaviour, IUnityAdsInitializationListener
{
    private const string ANDROID_GAME_ID = "5598791";
    private const string IOS_GAME_ID = "5598790";
    private string gameId;
    private bool testMod = true;

    private void Awake()
    {
        Init();
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Ad Initialized");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Ad Initialize failed");
    }

    private void Init()
    {
        gameId = Application.platform == RuntimePlatform.Android ? ANDROID_GAME_ID : IOS_GAME_ID;
        Advertisement.Initialize(gameId, testMod, this);
    }
}
