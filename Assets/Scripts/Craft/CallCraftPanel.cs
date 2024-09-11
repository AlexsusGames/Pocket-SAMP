using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CallCraftPanel : MonoBehaviour
{
    [SerializeField] private CraftVisual vizual;
    [SerializeField] private Animator animator;
    [SerializeField] private Button craftButton;
    private bool isImproving;
    private ItemsCrafting itemsCrafting;
    private WorkBenchImprover workBenchImprover;
    private SoCraftData soCraftData;
    private int countOfCrafts;

    private void Awake()
    {
        itemsCrafting = GetComponent<ItemsCrafting>();
        workBenchImprover = GetComponent<WorkBenchImprover>();
    }
    public void OpenVizual(SoCraftData data, bool value, int countOfCrafts)
    {
        vizual.gameObject.SetActive(true);
        vizual.SetData(data, countOfCrafts);
        isImproving = value;
        soCraftData = data;
        this.countOfCrafts = countOfCrafts;
    }
    private IEnumerator Timer()
    {
        craftButton.interactable = false;
        animator.enabled = true;
        for (int i = 0; i < countOfCrafts; i++)
        {
            yield return new WaitForSeconds(1);
            if (isImproving)
            {
                workBenchImprover.ImproveWorkbenchLevel();
                vizual.gameObject.SetActive(false);
            }
            else itemsCrafting.ItemCrafting(soCraftData);
        }
        craftButton.interactable = true;
        animator.enabled = false;
        vizual.SetData(soCraftData, countOfCrafts);
    }
    public void StartCrafting()
    {
        StartCoroutine(Timer());
    }
    
}
