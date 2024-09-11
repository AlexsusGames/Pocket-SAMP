using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPoint : MonoBehaviour
{
    [SerializeField] private List<ItemId> resources = new List<ItemId>();
    [SerializeField] private ShopRes shop;
    [SerializeField] private SoResourcesInfo info;
    private List<Sprite> sprites = new List<Sprite>();
    private void Awake()
    {
        LoadSprites();
    }
    public void OpenShop()
    {
        shop.SetResourcesCount(sprites, resources);
    }
    private void LoadSprites()
    {
        sprites.Clear();
        for (int i = 0; i < resources.Count; i++)
        {
            sprites.Add(info.GetResSprite(resources[i]));
        }
    }
}
