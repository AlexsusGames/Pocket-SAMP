using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private ClickEffectPool pool;
    private int currentRes;

    private void Activate(int res)
    {
        ChangeRes(res);
        var obj = pool.GetClickEffect();
        Vector2 clickPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(Input.touchCount - 1).position);
        obj.transform.position = clickPos;
        obj.TryGetComponent(out Effect effect);
        effect.SetSpite(sprites[currentRes]);
    }
    private void OnEnable()
    {
        WorkPayment.spriteID += Activate;
    }
    private void OnDisable()
    {
        WorkPayment.spriteID -= Activate;
    }
    private void ChangeRes(int resId)
    {
        currentRes = resId;
    }
}
