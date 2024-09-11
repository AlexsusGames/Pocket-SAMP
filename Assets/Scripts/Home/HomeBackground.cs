using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBackground : MonoBehaviour
{
    [SerializeField] private List<Sprite> homeSprites = new List<Sprite>();
    [SerializeField] private SpriteRenderer background;
    private void Awake()
    {
        int index = PlayerPrefs.GetInt("House");
        background.sprite = homeSprites[index];
    }
}
