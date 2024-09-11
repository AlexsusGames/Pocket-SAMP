using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarAnimation : MonoBehaviour
{
    [SerializeField] private Image mainHealthBar;
    [SerializeField] private Image animatedHealthBar;
    private float currentTime = 0;

    private void Update()
    {
        if(animatedHealthBar.fillAmount - mainHealthBar.fillAmount > 0.001f)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / 50;
            animatedHealthBar.fillAmount = Mathf.Lerp(animatedHealthBar.fillAmount, mainHealthBar.fillAmount, t);
        }
        else
        {
            currentTime = 0;
            animatedHealthBar.fillAmount = mainHealthBar.fillAmount;
        }
    }
}
