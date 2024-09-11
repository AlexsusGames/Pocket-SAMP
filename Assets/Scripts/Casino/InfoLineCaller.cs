using System.Collections;
using System.Collections.Generic;
using System.Media;
using TMPro;
using UnityEngine;

public class InfoLineCaller : MonoBehaviour
{
    [SerializeField] private Color winColor;
    [SerializeField] private Color defColor;
    [SerializeField] private GameObject line;
    [SerializeField] private TMP_Text text;
    private bool isWin;

    public void CallInfoLine(string info, bool _isWin)
    {
        isWin = _isWin;
        GetComponent<AudioPlayer>().Play();
        StartCoroutine(Timer(info));
    }
    private IEnumerator Timer(string info)
    {
        line.SetActive(true);
        text.text = info;
        text.color = isWin? winColor : defColor;
        yield return new WaitForSeconds(2);
        line.SetActive(false);
    }
}
