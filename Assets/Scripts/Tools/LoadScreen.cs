using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    public static LoadScreen instance = null;
    private Canvas canvas;
    [SerializeField] private Animator animator;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text clueText;
    [SerializeField] private string[] clues;

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ShowLoadScreen(float time)
    {
        StartCoroutine(Timer(time));
        Resources.UnloadUnusedAssets();
    }
    private IEnumerator Timer(float time)
    {
        animator.SetTrigger("playAnim");
        if(clueText != null ) 
        clueText.text = clues[Random.Range(0, clues.Length)];
        canvas.enabled = true;
        yield return new WaitForSeconds(time);
        canvas.enabled = false;
    }
}
