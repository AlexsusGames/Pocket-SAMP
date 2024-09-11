using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStatsCalculater 
{
    private float speedFromTuning;
    private float accelerationFromTuning;

    public float GetSpeed(float speed, ItemId[] tuning)
    {
        SpeedCalculating(tuning);
        float result = speed / 100 * speedFromTuning;
        result += speed;
        return result;
    }
    private void SpeedCalculating(ItemId[] id)
    {
        speedFromTuning = 0;
        for (int i = 0; i < id.Length; i++)
        {
            float speed = 0;
            switch (id[i])
            {
                case ItemId.NagnetatelImprove: speed = 2f; break;
                case ItemId.KolenvalImprove: speed = 5f; break;
                case ItemId.NagnetatelSport: speed = 5; break;
                case ItemId.KolenvalSport:  speed = 10f; break;
                case ItemId.NagnetatelSportPlus: speed = 10; break;
                case ItemId.KolenvalSportPlus: speed = 15f; break;
            }
            speedFromTuning += speed;
        }
    }
    public float GetAcceleration(float acceleration, ItemId[] tuning)
    {
        AccelerationCalculating(tuning);
        float addition = acceleration / 100 * accelerationFromTuning;
        float result = acceleration - addition;
        return result;
    }
    private void AccelerationCalculating(ItemId[] id)
    {
        accelerationFromTuning = 0;
        for (int i = 0; i < id.Length; i++)
        {
            float acceleration = 0;
            switch (id[i])
            {
                case ItemId.TurbocompressorImprove:
                case ItemId.KppImprove: acceleration = 10f; break;
                case ItemId.TurbocompressorSport:
                case ItemId.KppSport: acceleration = 20f; break;
                case ItemId.KppSportPlus:
                case ItemId.TurbocompressorSportPlus: acceleration = 30f; break;
            }
            accelerationFromTuning += acceleration;
        }
    }
}
