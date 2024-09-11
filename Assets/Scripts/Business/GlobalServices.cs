using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalServices : MonoBehaviour
{
    private PayDayManager payDayManager = new();
    private GhettoState ghettoState = new ();
    private FuelFiller fuelFiller = new();
    private GhettoSimulation ghettoSimulation;
    private OnlineServices onlineServices = new();

    public static OnlineServices instance = null;

    private void Awake()
    {
        StartWorking();
        instance = onlineServices;
    }

    private async void StartWorking()
    {
        ghettoSimulation = new(ghettoState);
        StartCoroutine(ghettoSimulation.GhettoTimer());
        StartCoroutine(payDayManager.PayDayTimer());
        StartCoroutine(fuelFiller.FuelTimer(180));
        await onlineServices.Init();
    }
    private void OnDisable() => fuelFiller.SaveTime();
}
