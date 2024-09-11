using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationTimer : MonoBehaviour
{
    [SerializeField] private List<string> _timers = new List<string>();
    private Animator animator;
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        animator = GetComponent<Animator>();
    }
    public void StartTimer()
    {
        StartCoroutine(Timer());
    }
    
    private IEnumerator Timer()
    {
        animator.enabled = true;
        animator.SetTrigger("start");
        for (int i = 0; i < _timers.Count; i++)
        {
            text.text = _timers[i];
            yield return new WaitForSeconds(1);
        }
        text.text = "";
    }
}
