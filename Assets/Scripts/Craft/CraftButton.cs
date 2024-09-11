using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftButton : MonoBehaviour
{ 
    [SerializeField] private List<Image> resImages = new List<Image>();
    [SerializeField] private Image craftItem;
    [SerializeField] private SoResourcesInfo resourcesSprites;
    [SerializeField] private TMP_Text countText;
    private int countOfCrafts = 1;

    public void SetData(SoCraftData data)
    {
        craftItem.sprite = data.ItemSprite;
        for (int i = 0; i < data.Resources.Count; i++)
        {
            resImages[i].sprite = resourcesSprites.GetResSprite(data.Resources[i]);
        }
        countText.text = countOfCrafts.ToString();
    }
    public void SetCount(int count)
    {
        countOfCrafts += count;
        if (countOfCrafts < 1) countOfCrafts = 1;
        countText.text = countOfCrafts.ToString();
    }
    public int GetCount()
    {
        return countOfCrafts; 
    }
}
