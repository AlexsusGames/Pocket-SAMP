using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WorkBenchImprover : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private List<SoCraftData> workbenchLevels = new List<SoCraftData> ();
    [SerializeField] private InfoTabCaller info;
    [SerializeField] private CraftVisual craftTab;
    [SerializeField] private InfoLineCaller infoLine;
    [SerializeField] private Button improvingButton;
    [SerializeField] private CallCraftPanel craftPanel;
    [SerializeField] private UnityEvent OnImpoving;
    private HouseDataLoader houseDataLoader = new HouseDataLoader();
    private CraftProcess craftProcess = new CraftProcess();
    private int houseIndex;
    private int workbenchLevel;
    private int houseStars;

    private void OnEnable()
    {
        SetData();
    }
    public void ImproveWorkbenchLevel()
    {
        var craftInfo = craftProcess.Craft(workbenchLevels[workbenchLevel - 1]);
        if (craftInfo.success)
        {
            houseDataLoader.ImproveWorkbench(houseIndex, workbenchLevel + 1);
            info.CallInfoPanel("Верстак улучшен!");
            infoLine.CallInfoLine("Successful", true);
            SetData();
            OnImpoving.Invoke();

        }
        else info.CallInfoPanel(craftInfo.msg);
    }
    private void SetData()
    {
        houseIndex = PlayerPrefs.GetInt("House");
        HousesData data = houseDataLoader.GetHouseData();
        workbenchLevel = data.Houses[houseIndex].WorkbenchLevel;
        levelText.text = $"Уровень подвала: <color=green>{workbenchLevel}";
        houseStars = data.Houses[houseIndex].StarsIndex + 1;
        ButtonImprove();
    }
    private void ButtonImprove()
    {
        if (workbenchLevel < houseStars)
        {
            improvingButton.onClick.AddListener(() => craftPanel.OpenVizual(workbenchLevels[workbenchLevel - 1], true, 1));
        }
        else if(workbenchLevel == 5) improvingButton.onClick.AddListener(() => info.CallInfoPanel("В этом доме верстак максимального уровня!"));
        else improvingButton.onClick.AddListener(() => info.CallInfoPanel("В этом доме не хватит места для улучшеного верстака!"));
    }
}
