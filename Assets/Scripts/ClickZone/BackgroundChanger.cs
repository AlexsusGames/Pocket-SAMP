using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprites = new List<Sprite>();
    private SpriteRenderer _spriteRenderer;
    private void Awake() => _spriteRenderer = GetComponent<SpriteRenderer>();
    public void SetBackGround(int index)
    {
        _spriteRenderer.sprite = _sprites[index];
    }
}
