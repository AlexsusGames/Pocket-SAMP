using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EffectTimer : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTimerZero;
    [SerializeField] private InteractiveItemSpawner effects;
    private float time;
    private bool isEnable;

    private void Update()
    {
        if(time >= 0)
        {
            time -= Time.deltaTime;
            if(isEnable)
            {
                effects.Activate();
                isEnable = false;
            }
        }
        else
        {
            OnTimerZero.Invoke();
            isEnable = true;
        }
    }
    public void SetTimer()
    {
        time = 1;
    }
}
