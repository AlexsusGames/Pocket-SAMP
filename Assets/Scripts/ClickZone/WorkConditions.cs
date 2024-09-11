using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorkConditions : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> conditionTexts = new List<TMP_Text>();
    [SerializeField] private SoWork workData;
    [SerializeField] private int index;
    private WorkDataChanger data = new WorkDataChanger();
    private Button button;
    private bool firstCondition;
    private bool secondCondition;
    private bool thirtCondition;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadWork);
    }
    private void OnEnable ()
    {
        CheckConditions();
    }
    private void HouseAvailable()
    {
        int house = PlayerPrefs.GetInt("House");
        if(house >= workData.NeedHouse) firstCondition = true;
        conditionTexts[0].text = firstCondition == true ? "<color=green>Уровень дома достаточен!" : $"<color=red>Требуется уровень дома {workData.HouseLevel}!";
    }
    private void SkinAvailable()
    {
        int skin = PlayerPrefs.GetInt("Avatar");
        if (skin == workData.NeedSkin || workData.IsCanEmploy && skin > 5) secondCondition = true;
        conditionTexts[1].text = secondCondition == true ? "<color=green>Форма одета!" : "<color=red>Требуется рабочая форма!";
    }
    private void EmploymentAvailable()
    {
        if (!workData.IsCanEmploy || data.CheckEmployee(index)) thirtCondition = true; 
        conditionTexts[2].text = thirtCondition == true ? "<color=green>Трудоустройство не требуется!" : "<color=red>Требуется трудоустройство!";
    }

    private void CheckConditions()
    {
        HouseAvailable();
        SkinAvailable();
        EmploymentAvailable();
        if (firstCondition && secondCondition && thirtCondition)
        {
            button.interactable = true;
        }
        else button.interactable = false;
    }
    private void LoadWork()
    {
        LoadScreen.instance.ShowLoadScreen(0.5f);
        SceneManager.LoadScene(1);
    }
}
