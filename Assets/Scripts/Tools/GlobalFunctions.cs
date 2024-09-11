using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalFunctions : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    [SerializeField] private Button buttonSaveName;
    [SerializeField] private Button buttonStart;
    [SerializeField] private GameObject inputWindow;
    private const string Key = "NickName";
    private OnlineServices services = new();

    public async void Init()
    {
        await services.Init();
    }
    private void Start()
    {
        Init();
        if (!PlayerPrefs.HasKey(Key))
        {
            input.onValueChanged.AddListener(CheckNickname);
            inputWindow.SetActive(true);
            CheckNickname(input.text);
            buttonStart.interactable = false;
        }
        else inputWindow.SetActive(false);
    }
    private void CheckNickname(string name)
    {
        if(name.Length > 3 && name.Length < 20)
        {
            buttonSaveName.interactable = true;
        }
        else buttonSaveName.interactable = false;
    }
    public void ConfirmNick()
    {
        PlayerPrefs.SetString(Key, input.text);
        inputWindow.SetActive(false);
        buttonStart.interactable = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void InClickZone()
    {
        LoadScreen.instance.ShowLoadScreen(0.5f);
        SceneManager.LoadScene(1);
    }
}
