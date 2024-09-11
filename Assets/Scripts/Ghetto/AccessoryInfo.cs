using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AccessoryInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text textName;
    [SerializeField] private TMP_Text textDamage;
    [SerializeField] private TMP_Text textTotalDamage;

    public void SetData(SoAccessory data,int totalDamage)
    {
        textName.text = $"Название: <color=green>{data.Name}";
        textDamage.text = $"Бонус к урону: <color=green>{data.Damage}";
        textTotalDamage.text = $"Общий бонус к урону: <color=green>{totalDamage}";
    }
}
