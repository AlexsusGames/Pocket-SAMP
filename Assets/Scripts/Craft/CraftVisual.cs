using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftVisual : MonoBehaviour
{
    [SerializeField] private List<Image> imageCells = new List<Image>();
    [SerializeField] private SoResourcesInfo resSprites;
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text chanceText;
    [SerializeField] private Button createButton;
    [SerializeField] private TMP_Text countText;
    [Space]
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text describtionText;
    private List<TMP_Text> resAmounts = new List<TMP_Text>();
    private ItemsData resData = new ItemsData();
    private CharactersBonuses bonuses = new CharactersBonuses();
    private GetItemInfo itemInfo = new GetItemInfo();
    
    public void SetData(SoCraftData data, int countOfCrafts)
    {
        SetStandart();
        countText.text = countOfCrafts.ToString();
        if(resAmounts.Count != 0)
        {
            for (int i = 0; i < data.Resources.Count; i++)
            {
                imageCells[i].gameObject.SetActive(true);
                imageCells[i].sprite = resSprites.GetResSprite(data.Resources[i]);
                resAmounts[i].text = $"{resData.GetRes(data.Resources[i])} / {data.ResourcesCount[i] * countOfCrafts}";
                if (resData.GetRes(data.Resources[i]) >= data.ResourcesCount[i] * countOfCrafts) resAmounts[i].color = Color.green;
                else
                {
                    resAmounts[i].color = Color.red;
                    createButton.interactable = false;
                }
            }
            itemImage.sprite = data.ItemSprite;
            if(data.CraftItem > (ItemId)1)
            {
                nameText.text = itemInfo.GetItemName(data.CraftItem);
                describtionText.text = itemInfo.GetItemDescription(data.CraftItem);
            }
            else
            {
                nameText.text = "Улучшение верстака";
                describtionText.text = "Увеличивает количество доступных крафтов";
            }
            if (bonuses.IsDoubleChanceCraft()) chanceText.text = $"Шанс на успех - <color=green>{data.CraftChance}% + {data.CraftChance}%";
            else chanceText.text = $"Шанс на успех - <color=green>{data.CraftChance}%";
        }
        else
        {
            GetTexts();
            SetData(data,countOfCrafts);
        }
    }
    private void GetTexts()
    {
        for (int i = 0; i < imageCells.Count; i++)
        {
            resAmounts.Add(imageCells[i].GetComponentInChildren<TMP_Text>());
        }
    }
    private void SetStandart()
    {
        createButton.interactable = true;
        for (int i = 0; i < imageCells.Count; i++)
        {
            imageCells[i].gameObject.SetActive(false);
        }
    }
}
