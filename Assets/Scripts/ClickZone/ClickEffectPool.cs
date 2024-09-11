using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickEffectPool : MonoBehaviour
{
    [SerializeField] private GameObject clickEffect;
    private List<GameObject> clickEffects = new List<GameObject>();
    private int effectCount = 7;
    private void OnEnable()
    {
        CreatePool();      
    }
    private void OnDisable()
    {
        DissablePool();
    }
    private void DissablePool()
    {
        for (int i = 0; i < effectCount; i++)
        {
            clickEffects[i].SetActive(false);
        }
    }
    private void CreatePool()
    {
        for (int i = 0; i < effectCount; i++)
        {
            var effect = Instantiate(clickEffect, transform);
            clickEffects.Add(effect);
            effect.SetActive(false);
        }
    }
    public GameObject GetClickEffect()
    {
        for (int i = 0; i < effectCount; i++)
        {
            if (!clickEffects[i].activeInHierarchy)
            {
                clickEffects[i].SetActive(true);
                return clickEffects[i];
            }
        }
        return null;
    }
}
