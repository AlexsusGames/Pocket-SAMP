using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VideocardImprovingPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text textInfo;
    [SerializeField] private Button button;
    
    public void OpenPanel(Videocard videocard,UnityAction action)
    {
        button.onClick.RemoveAllListeners();
        int videocardLevel = videocard.Level;
        float videocardProfit = videocard.Profit;
        int chance = 100 - videocardLevel * 10;
        textInfo.text = $"��� ������� ��������� <color=green>'������ ��� ����������'</color> � ���������� <color=green>2</color>��." +
            $"\n������� {videocardLevel} >> {videocardLevel + 1}\nAZ/PayDay {videocardProfit} >> {videocardProfit + 0.3f}\n���� �� ����� - <color=green>{chance}%</color>.";
        button.onClick.AddListener(action);
        button.onClick.AddListener(() => transform.parent.gameObject.SetActive(false));
    }
}
