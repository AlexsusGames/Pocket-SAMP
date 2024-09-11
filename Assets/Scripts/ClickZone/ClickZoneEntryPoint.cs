using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickZoneEntryPoint : MonoBehaviour
{
    [SerializeField] private BackgroundChanger background;
    [SerializeField] private WorkBlocker workBlocker;
    [SerializeField] private ChatLog chatLog;
    [SerializeField] private TutorShower tutor;
    [SerializeField] private ButtonClick clicker;
    [SerializeField] private InteractiveItemSpawner spawner;
    [SerializeField] private CharacterNeeds needs;
    [SerializeField] private ClickMultiplier multiplier;
    private WorkPayment workPayment = new();
    private WorkDataChanger workDataChanger = new();
    private SoWork[] allWorks;
    private int skinIndex;

    private void Awake()
    {
        skinIndex = PlayerPrefs.GetInt("Avatar") - 1;
        allWorks = Resources.LoadAll<SoWork>("Works");
    }
    private void Start()
    {
        SetState();
    }
    private SoWork GetWork(int index)
    {
        for (int i = 0; i < allWorks.Length; i++)
        {
            if (allWorks[i].WorkId == index && workDataChanger.IsHouseAvailable(i) && !allWorks[i].IsCanEmploy) return allWorks[i];
            if (!allWorks[i].IsCanEmploy) continue;
            if(workDataChanger.GetWorkProgress(i).IsEmployment && skinIndex >= 5) return allWorks[i];
        }
        return null;
    }
    private void SetState()
    {
        var workBySkin = GetWork(skinIndex);
        if(workBySkin != null)
        {
            workBlocker.SetWork(workBySkin.WorkId);
            background.SetBackGround(workBySkin.WorkId + 1);
            workPayment.SetData(workBySkin,chatLog);
            clicker.SetData(workPayment);
            spawner.SetData(workBySkin, needs);
            multiplier.SetData(workPayment.factor);
        }
        else
        {
            tutor.isEnable = false;
            background.SetBackGround(0);
            workBlocker.EnabledClickZone(false);
        }
    }
    public void GoHome()
    {
        SceneManager.LoadScene(3);
        LoadScreen.instance.ShowLoadScreen(0.5f);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(0);
        LoadScreen.instance.ShowLoadScreen(0.5f);
    }
    public void TutorAction()
    {
        Wallet wallet = new();
        if(wallet.GetMoney() < 2000)
        wallet.MoneyOperation(2000);
    }
    public void TutorAction2()
    {
        PlayerPrefs.SetInt("Location", (int)Locations.ClothShop);
        LoadScreen.instance.ShowLoadScreen(0.5f);
        SceneManager.LoadScene(4);
    }
}
