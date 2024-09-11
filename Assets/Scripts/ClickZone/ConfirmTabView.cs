using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConfirmTabView : MonoBehaviour
{
    [SerializeField] private TMP_Text info;
    [SerializeField] private Button button;

    public void SetData(string text,UnityAction action)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(action);
        info.text = text;
    }
}
