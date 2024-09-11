using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    public static Action<Transform> OnSelect;

    public void Select()
    {
        OnSelect?.Invoke(transform);
    }
}
