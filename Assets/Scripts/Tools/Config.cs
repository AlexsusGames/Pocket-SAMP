using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 100;
        if (!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", 0);
        }
        if (!PlayerPrefs.HasKey("Res"))
        {
            PlayerPrefs.SetInt("Res", 0);
        }
        if (!PlayerPrefs.HasKey("Craft"))
        {
            PlayerPrefs.SetInt("Craft", 0);
        }
    } 
}
