using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopRes : MonoBehaviour
{
    private List<Sprite> resourcesSprites = new List<Sprite>();
    private List<ItemId> resourcesNames = new List<ItemId>();
    [SerializeField] private List<Button> buttonShop = new List<Button>();
    [SerializeField] private List<Button> buttonSell = new List<Button>();

    private void OnEnable()
    {
        ShowPrices();
        ShowCosts();
    }
    private void OnDisable()
    {
        DisableButtons(buttonSell);
        DisableButtons(buttonShop);
    }
    public void SetResourcesCount(List <Sprite> sprites,List<ItemId> names)
    {
        resourcesSprites = sprites;
        resourcesNames = names;
    }
    private void ShowPrices()
    {
        SetData(buttonShop);
    }
    private void ShowCosts()
    {
        SetData(buttonSell);
    }
    private void SetData(List<Button> buttons)
    {
        for (int i = 0; i < resourcesSprites.Count; i++)
        {
            buttons[i].gameObject.SetActive(true);
            buttons[i].image.sprite = resourcesSprites[i];
            buttons[i].TryGetComponent(out ShopButtonData data);
            data.SetData(resourcesNames[i]);
        }
    }
    private void DisableButtons(List<Button> buttons)
    {
        for(int i = 0;i < buttons.Count; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
    }
}
