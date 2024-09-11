using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RaceCar raceCar;
    private bool isMoving;
    private RaceResult raceResult;

    public void PrepareCamera(RaceResult result)
    {
        isMoving = true;
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 36455.34f);
        raceResult = result;
        raceResult.onFinish += StopMoving;
    }

    private void Update()
    {
        if (isMoving)
        {
            Vector2 currentSpeed = rectTransform.anchoredPosition;
            currentSpeed.y -= raceCar.GetCurrentSpeed() * Time.deltaTime;
            rectTransform.anchoredPosition = currentSpeed;
        }
    }
    private void StopMoving(bool result)
    {
        isMoving = false;
        raceResult.onFinish -= StopMoving;
    }
}
