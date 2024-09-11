using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryInventory : MonoBehaviour
{
    [SerializeField] private Transform content;
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private AccessoryInfo info;
    private GhettoStatsData data = new();
    private List<GameObject> objects = new List<GameObject>();
    private AccessoryFinder finder = new AccessoryFinder();

    private void OnEnable()
    {
        Clear();
        SpawnButtons();
        info.gameObject.SetActive(false);
    }
    private void OpenInfoPanel(SoAccessory accessory)
    {
        info.gameObject.SetActive(true);
        info.SetData(accessory,data.GetDamage());
    }

    private void SpawnButtons()
    {
        var names = data.GetNames();
        for (int i = 0; i < names.Count; i++)
        {
            var button = Instantiate(buttonPrefab, content);
            button.TryGetComponent(out AccessoryButtonVisual visual);
            visual.SetData(finder.GetAccessoryByName(names[i]));
            button.onClick.AddListener(() => OpenInfoPanel(visual.AccessoryData));
            objects.Add(visual.gameObject);
        }
    }
    private void Clear()
    {
        foreach (var obj in objects)
        {
            Destroy(obj);
        }
        objects.Clear();
    }
}
