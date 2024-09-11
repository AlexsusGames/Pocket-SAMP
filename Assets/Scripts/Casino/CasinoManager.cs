using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasinoManager : MonoBehaviour
{
    [SerializeField] private GameObject blockTab;
    [SerializeField] private InfoTabCaller info;
    
    public void EnterToCasino()
    {
        int skin = PlayerPrefs.GetInt("Avatar");
        switch (skin)
        {
            case 0: info.CallInfoPanel("� ������ ������ �� �������!"); break;
            case 1: case 2: case 3: case 4: case 5: info.CallInfoPanel("� ������ � ������� ����� �� �������!"); break;
            default: info.CallInfoPanel("����� ���������� � ������!");
                     blockTab.SetActive(false); break;
        }
    }
}
