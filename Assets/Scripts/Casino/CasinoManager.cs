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
            case 0: info.CallInfoPanel("В казино бомжей не пускают!"); break;
            case 1: case 2: case 3: case 4: case 5: info.CallInfoPanel("В казино в рабочей форме не пускают!"); break;
            default: info.CallInfoPanel("Добро пожаловать в казино!");
                     blockTab.SetActive(false); break;
        }
    }
}
