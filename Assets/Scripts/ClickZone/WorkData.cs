using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorkData 
{
    public List<WorkProgress> progress = new List<WorkProgress>();
}
[System.Serializable]
public class WorkProgress
{
    public bool IsCanEmploy;
    public bool IsEmployment;
    public int Rang;
}
