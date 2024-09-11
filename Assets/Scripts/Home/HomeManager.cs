using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    [SerializeField] private GameObject craftPanel;
    [SerializeField] private GameObject garagePanel;
    [SerializeField] private InfoTabCaller infoTab;
    [SerializeField] private UnityEvent onTutotialComplete;

    private void Awake()
    {
        TutorShower tutor = GetComponent<TutorShower>();
        int house = PlayerPrefs.GetInt("House");
        tutor.enabled = house > 0;
    }
    public void GoToWork()
    {
        LoadScreen.instance.ShowLoadScreen(0.5f);
        SceneManager.LoadScene(1);
    }
    public void OpenCraftPanel()
    {
        if (PlayerPrefs.GetInt("Craft") > 0)
        {
            craftPanel.SetActive(true);
        }
        else infoTab.CallInfoPanel($"В этом доме отсутствует верстак!");
    }
    public void OpenGaragePanel()
    {
        if (PlayerPrefs.GetInt("Garage") > 0)
        {
            garagePanel.SetActive(true);
        }
        else infoTab.CallInfoPanel($"В этом доме отсутсвует гараж!");
    }
    public void TutorAction()
    {
        if (PlayerPrefs.GetInt("Avatar") > 0)
            onTutotialComplete?.Invoke();
        else infoTab.CallInfoPanel("Сперва оденьте одежду в Меню дома!");
    }
}
