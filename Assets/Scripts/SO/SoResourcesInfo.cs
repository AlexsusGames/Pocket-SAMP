using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ResSprites",fileName = "ResSprites")]
public class SoResourcesInfo : ScriptableObject
{
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();

    public Sprite GetResSprite(ItemId res)
    {
        return sprites[(int)res];
    }
}
