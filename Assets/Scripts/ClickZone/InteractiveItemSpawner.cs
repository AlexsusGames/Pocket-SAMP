using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractiveItemSpawner : MonoBehaviour
{
    [SerializeField] private ButtonCreator creator;
    [SerializeField] private SoResourcesInfo info;
    [SerializeField] private List<Sprite> bonusSprites = new();
    private InteractiveBonuses bonuses;


    public void SetData(SoWork work,CharacterNeeds needs)
    {
        bonuses = new(work,needs);
    }
    public void Activate() => StartCoroutine(Timer());
    private void OnDisable() => StopAllCoroutines();
    private IEnumerator Timer()
    {
        while (true)
        {
            CreateBonus();
            yield return new WaitForSeconds(1);
        }
    }
    private void CreateBonus()
    {
        var obj = creator.CreateObject();
        var bonus = bonuses.GetBonus();
        Sprite sprite = bonus.ActionId == 0 ? info.GetResSprite(bonus.ItemId) : bonusSprites[bonus.ActionId];
        obj.TryGetComponent(out InteractiveItemButton bonusItem);
        bonusItem.SetData(bonus.Action, sprite);
    }

}