using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoTabCaller : MonoBehaviour
{
    [SerializeField] private TMP_Text textInfo;
    private Vector2 startPos;
    private Animator animator;
    private RectTransform rectTransform;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
    }

    public void CallInfoPanel(string info)
    {
        StartCoroutine(Action(info));
    }
    private IEnumerator Action(string info)
    {
        animator.enabled = true;
        rectTransform.anchoredPosition = startPos;
        animator.SetTrigger("anim");
        textInfo.text = info;
        yield return new WaitForSeconds(3);
        while(rectTransform.transform.position.y > -100)
        {
            yield return new WaitForSeconds(0.1f);
        }
    }
}
