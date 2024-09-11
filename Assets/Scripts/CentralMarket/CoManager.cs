using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoManager : MonoBehaviour
{
    [SerializeField] private Camera cam;

    public void BackToPlayZone()
    {
        LoadScreen.instance.ShowLoadScreen(0.5f);
        SceneManager.LoadScene(1);
    }
}
