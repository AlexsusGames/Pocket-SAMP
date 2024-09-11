using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCreator : MonoBehaviour
{
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private RectTransform parentRect;
    [SerializeField] private RectTransform borders;

    public GameObject CreateObject()
    {
        var obj = Instantiate(buttonPrefab, parentRect);
        obj.TryGetComponent(out RectTransform rect);
        rect.anchoredPosition = GetPosition();
        obj.gameObject.SetActive(true);
        return obj.gameObject;
    }
    private Vector2 GetPosition()
    {
        return new Vector2(Random.Range(0, borders.anchoredPosition.x * 2),0);
    }
}
