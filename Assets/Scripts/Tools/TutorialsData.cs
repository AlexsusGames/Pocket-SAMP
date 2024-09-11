using UnityEngine;

public class TutorialsData
{
    public bool CheckProgress(string data)
    {
        if(PlayerPrefs.GetInt(data) > 0) return true;
        return false;
    }
    public void CompleteTutor(string data)
    {
        PlayerPrefs.SetInt(data, 1);
    }
}
