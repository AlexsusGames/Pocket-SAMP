using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectImageSpawner : MonoBehaviour
{
    private void OnEnable() => SelectableObject.OnSelect += SelectPlace;
    private void OnDisable()
    {
        SelectableObject.OnSelect -= SelectPlace;
        transform.position = new Vector3 (10000, 0, 0);
    }

    private void SelectPlace(Transform transform)
    {
        RectTransform position = gameObject.GetComponent<RectTransform>();
        position.SetParent(transform, true);
        position.anchoredPosition = Vector2.zero;
    }    
}
