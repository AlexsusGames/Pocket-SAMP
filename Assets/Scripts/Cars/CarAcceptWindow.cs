using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CarAcceptWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text carName;
    [SerializeField] private TMP_Text dealText;
    [SerializeField] private TMP_Text actText;
    public void SetData(string name, string info, string buttonAction)
    {
        gameObject.SetActive(true);
        carName.text = name;
        dealText.text = info;
        actText.text = buttonAction;
    }
}
