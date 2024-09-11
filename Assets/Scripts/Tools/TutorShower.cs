using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorShower : MonoBehaviour
{
    [SerializeField] private GameObject TutorWindow;
    [SerializeField] private string TutorKey;
    private TutorialsData data = new();
    public bool isEnable = true;

    private void Start()
    {
        if(!data.CheckProgress(TutorKey) && isEnable) TutorWindow.SetActive(true);
    }
    public void Complete()
    {
        data.CompleteTutor(TutorKey);
    }
}
