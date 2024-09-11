using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractiveItemButton : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    private float speed = 1000f;
    private RectTransform rect;
    private Animator animator;
    private Button button;
    private bool isMove = true;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        animator = GetComponent<Animator>();
        button = GetComponent<Button>();
    }

    public void SetData(UnityAction action, Sprite iconSprite)
    {
        itemImage.sprite = iconSprite;
        button.onClick.AddListener(OnClick);
        button.onClick.AddListener(action);
    }
    public void OnClick()
    {
        button.interactable = false;
        animator.SetTrigger("click");
        isMove = false;
        Invoke(nameof(Die),0.5f);
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void Update()
    {
        if(isMove)
        {
            rect.Translate(Vector3.down * speed * Time.deltaTime);
            if (rect.anchoredPosition.y < -2500) gameObject.SetActive(false);
        }
    }
}
