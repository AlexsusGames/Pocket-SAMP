using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent actions;
    private Vector2 defaultPos;

    private void Awake()
    {
        gameObject.TryGetComponent(out RectTransform rectTransform);
        if (rectTransform != null) defaultPos = rectTransform.anchoredPosition;
    }
    private void OnEnable()
    {
        actions.Invoke();
    }
    public void SetStandartPos()
    {
        gameObject.TryGetComponent(out RectTransform rectTransform);
        if (rectTransform != null) rectTransform.anchoredPosition = defaultPos;
    }
}
