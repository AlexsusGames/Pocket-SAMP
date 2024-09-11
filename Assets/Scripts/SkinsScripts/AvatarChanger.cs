using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarChanger : MonoBehaviour
{
    [SerializeField] private Image avatar;
    private SoResourcesInfo avatarSkins;
    private void Awake()
    {
        avatarSkins = Resources.Load<SoResourcesInfo>("ResSprites/Avatar/AvararImages");
        UpdateSkin();
    }
    public void UpdateSkin()
    {
        avatar.sprite = avatarSkins.GetResSprite((ItemId)PlayerPrefs.GetInt("Avatar"));
    }
}
