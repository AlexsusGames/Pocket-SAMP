using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLocationBG : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private List<GameObject> tabs = new List<GameObject>();
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private InfoTabCaller infoTabCaller;
    private SkinDataChanger skinDataChanger = new();
    private int locId;

    private void Awake()
    {
        locId = PlayerPrefs.GetInt("Location");
        spriteRenderer.sprite = sprites[locId];
        tabs[locId].gameObject.SetActive(true);
    }
    public void ComeBack()
    {
        LoadScreen.instance.ShowLoadScreen(0.5f);
        SceneManager.LoadScene(1);
    }
    public void ComeHome()
    {
        if (skinDataChanger.GetSkinData().progress[1].IsOpen)
        {
            LoadScreen.instance.ShowLoadScreen(0.5f);
            SceneManager.LoadScene(3);
        }
        else infoTabCaller.CallInfoPanel("Сперва купите одежду фермера!");
    }
}
