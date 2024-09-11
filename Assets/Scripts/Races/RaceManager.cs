using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{
    [SerializeField] private RaceCar playerRaceCar;
    [SerializeField] private RaceCar enemyRaceCar;
    [SerializeField] private GameObject resultTab;
    [SerializeField] private RaceResult raceResult;
    [SerializeField] private AnimationTimer timer;
    [SerializeField] private PlayerCamera playerCamera;
    [SerializeField] private GameObject road;
    private EnemyCarCreater enemyCarCreater = new EnemyCarCreater();

    private SoCarData playerCar;
    private CarProgress playerData;


    private void OnEnable() => raceResult.onFinish += ShowResult;
    private void OnDestroy() => raceResult.onFinish -= ShowResult;

    public void SetPlayerData(SoCarData car,CarProgress data)
    {
        playerCar = car;
        playerData = data;
    }
    public void StartRace(int range, int difficult)
    {
        road.SetActive(true);
        PrepareCars(range, difficult);
        timer.StartTimer();
        raceResult.ClearLastResult();
        playerCamera.PrepareCamera(raceResult);
        Invoke(nameof(Beginning), 3);
    }
    private void ShowResult(bool result)
    {
        resultTab.SetActive(true);
        var reward = resultTab.GetComponentInParent<RaceReward>();
        var animator = resultTab.GetComponentInParent<Animator>();
        animator.enabled = true;
        animator.SetTrigger("start");
        reward.SetData(result);
    }
    private void PrepareCars(int range, int difficult)
    {
        var enemyData = enemyCarCreater.GetEnemyData(difficult);
        var enemysCar = enemyCarCreater.GetCarForRange(range);
        playerRaceCar.SetData(playerCar, playerData, true);
        enemyRaceCar.SetData(enemysCar, enemyData, false);
    }
    private void Beginning()
    {
        playerRaceCar.enabled = true;
        enemyRaceCar.enabled = true;
    }
}
