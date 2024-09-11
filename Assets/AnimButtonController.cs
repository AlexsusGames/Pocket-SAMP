using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Animator animator;

    private void OnEnable()
    {
        animator.SetTrigger("clicked");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        animator.enabled = true;
        animator.ResetTrigger("clicked");
        animator.SetTrigger("click");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        animator.ResetTrigger("click");
        animator.SetTrigger("clicked");
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

}
