using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Effect : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator animator;
    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }
    public void SetSpite(Sprite sprite)
    {
        sr.sprite = sprite;
        StartCoroutine(Timer());
        animator.enabled = true;
    }
    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.49f);
        animator.enabled = false;
        gameObject.SetActive(false);
    }
}
