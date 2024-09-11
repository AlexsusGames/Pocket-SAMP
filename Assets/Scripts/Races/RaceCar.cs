using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceCar : MonoBehaviour
{
    private float maxSpeed;
    private float accelerationTime;
    private float currentSpeed = 0;
    private float acceleration;
    private Image carSprite => GetComponent<Image>();
    private RectTransform rectTransform => GetComponent<RectTransform>();
    private CarStatsCalculater calculater = new CarStatsCalculater();
    public bool IsPlayer { get; private set; } 

    public void SetData(SoCarData carData,CarProgress carProgress, bool isPlayer)
    {
        IsPlayer = isPlayer;
        maxSpeed = calculater.GetSpeed(carData.Speed, carProgress.Tunning) * 10;
        accelerationTime = calculater.GetAcceleration(carData.Acceleration, carProgress.Tunning) * 100;
        carSprite.sprite = carData.TopSide;
        SetPosition();
        enabled = false;
    }
    private void SetPosition()
    {
        currentSpeed = 0;
        acceleration = maxSpeed / accelerationTime;
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -18350);
    }
    private void Update()
    {
        Vector2 currentPos = rectTransform.anchoredPosition;
        currentSpeed = Mathf.Lerp(currentSpeed,maxSpeed, acceleration * Time.deltaTime);
        currentPos.y += currentSpeed * Time.deltaTime;
        rectTransform.anchoredPosition = currentPos;
    }
    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }
}
