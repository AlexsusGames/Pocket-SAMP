using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;
using UnityEngine.UI;

public class RewardAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private const string ANDROID_ID = "Rewarded_Android";
    private const string IOS_ID = "Rewarded_iOS";
    private string id;

    [SerializeField] private UnityEvent OnWatching;
    [SerializeField] private UnityEvent OnCancelWatching;
    private Button button;

    private void Awake()
    {
        id = Application.platform == RuntimePlatform.Android ? ANDROID_ID : IOS_ID;
        button = GetComponent<Button>();
        button.interactable = false;
    }

    private void Start()
    {
        LoadAd();
    }

    public void LoadAd()
    {
        Advertisement.Load(id, this);
    }
    public void ShowAd()
    {
        Advertisement.Show(id, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("ad loaded");
        button.interactable = true;
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("ad loading failed");
        button.interactable = false;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if(placementId.Equals(id) && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            OnWatching?.Invoke();
            LoadAd();
        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        OnCancelWatching?.Invoke();
        LoadAd();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        
    }
}
