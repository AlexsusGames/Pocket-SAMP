using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OwnSkins : MonoBehaviour
{
    [SerializeField] private List<Sprite> skins = new List<Sprite>();
    [SerializeField] private Image skinImage;
    [SerializeField] private Image buttonImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text buttonText;
    private List<int> keys = new List<int>();
    private SkinDataChanger skinData = new SkinDataChanger();
    private SkinData data;
    private int _index;

    private void Awake()
    {
        CheckData();
        SetData(keys[_index]);
    }
    private void CheckData()
    {
        data = skinData.GetSkinData();
        for (int i = 0; i < data.progress.Count; i++)
        {
            if (data.progress[i].IsOpen)
            {
                keys.Add(i);
            }
        }
    }
    private void SetData(int index)
    {
        skinImage.sprite = skins[index];
        nameText.text = data.progress[index].Name;
        Check();
    }
    public void NextSkin()
    {
        if (_index < keys.Count - 1)
        {
            _index++;
            SetData(keys[_index]);
        }
    }
    public void PrevSkin()
    {
        if(_index > 0)
        {
            _index--;
            SetData(keys[_index]);
        }
    }
    public void EquipSkin()
    {
        PlayerPrefs.SetInt("Avatar", keys[_index]);
        Check();
    }
    private void Check()
    {
        if (PlayerPrefs.GetInt("Avatar") == keys[_index])
        {
            buttonText.text = "Одето";
            buttonImage.color = Color.yellow;
        }
        else
        {
            buttonText.text = "Одеть";
            buttonImage.color = Color.green;
        }
    }
}
