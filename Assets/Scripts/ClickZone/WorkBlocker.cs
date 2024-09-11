using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBlocker : MonoBehaviour
{
    [SerializeField] private List<GameObject> list = new List<GameObject>();
    [SerializeField] private ChatLog chatLog;
    private WorkDataChanger changer = new WorkDataChanger();
    private int currentWork;
    private bool isStoped = false;
    private Coroutine needs;

    public void SetWork(int workID)
    {
        currentWork = workID;
    }
    private IEnumerator Timer(string message)
    {
        while (true)
        {
            chatLog.AddMesage(message);
            yield return new WaitForSeconds(3);
        }
    }
    public void EnabledClickZone(bool value)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetActive(value);
        }
    }
    private void CheckEmployment()
    {
        if (!changer.GetWorkProgress(currentWork).IsEmployment)
        {
            StartCoroutine(Timer("<color=red>Вы тут не работаете!"));
            EnabledClickZone(false);
        }
    }
    private void OnEnable()
    {
        CharacterNeeds.onFull += ContinueWorking;
        CharacterNeeds.onTired += StopWorking;
        EmploymentCenterButton.OnUpdate += CheckEmployment;
    }
    private void OnDisable()
    {
        CharacterNeeds.onFull -= ContinueWorking;
        CharacterNeeds.onTired -= StopWorking;
        EmploymentCenterButton.OnUpdate -= CheckEmployment;
        StopAllCoroutines();
    }
    private void StopWorking(string message)
    {
        if (!isStoped)
        {
            EnabledClickZone(false);
            needs = StartCoroutine(Timer(message));
            isStoped = true;
        }
    }
    private void ContinueWorking()
    {
        if (isStoped)
        {
            EnabledClickZone(true);
            StopCoroutine(needs);
            isStoped = false;
        }
    }
}
