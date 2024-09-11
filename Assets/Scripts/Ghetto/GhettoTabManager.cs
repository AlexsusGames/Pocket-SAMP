using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhettoTabManager : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene(1);
        LoadScreen.instance.ShowLoadScreen(0.5f);
    }
}
