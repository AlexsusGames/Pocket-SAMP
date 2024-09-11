using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] 
public class RaceResult : MonoBehaviour
{
    public event Action<bool> onFinish;
    private RaceCar firstPlace;
    private TaskLoader task = new();

    public void ClearLastResult() => firstPlace = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out RaceCar car))
        {
            Debug.Log(car.IsPlayer);
            if (firstPlace == null) firstPlace = car;
            if (car.IsPlayer)
            {
                onFinish?.Invoke(firstPlace.IsPlayer);
                task.ChangeCount(KindOfTask.Races);
            }
        }
    }
}
