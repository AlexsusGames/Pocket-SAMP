using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhettoButtonSpawner : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private GhettoStateManager stateManager;
    [SerializeField] private InfoTabCaller info;
    private Wallet wallet = new();
    private float spaceBetweenButtons = 10f;
    private SoEnemiesData[] enemies;
    private RectTransform buttonRect => buttonPrefab.GetComponent<RectTransform>();
    private List<GameObject> objects = new List<GameObject>();

    private void Awake() => enemies = Resources.LoadAll<SoEnemiesData>("Enemies");
    private void OnEnable()
    {
        DeleteButtons();
        SetSize();
        SpawnButtons();
    }
    private void SpawnButtons()
    {
        float firstPositionY = -content.rect.yMin / 2 - buttonRect.sizeDelta.y / 2;
        for (int i = 0; i < enemies.Length; i++)
        {
            int index = i;
            var button = Instantiate(buttonPrefab, content);
            button.TryGetComponent(out RectTransform rectTransform);
            rectTransform.anchoredPosition = new Vector2(0, firstPositionY);
            firstPositionY -= rectTransform.sizeDelta.y + spaceBetweenButtons;
            button.TryGetComponent(out GhettoButtonVisual visual);
            visual.SetData(enemies[i]);
            objects.Add(visual.gameObject);
            if (wallet.GetRespects() >= enemies[i].NeedRespect)
            {
                button.onClick.AddListener(() => stateManager.StartFight(enemies[index]));
            }
            else button.onClick.AddListener(() => info.CallInfoPanel("Недостаточно очков <color=#7884cd>Уважения</color>"));
        }
    }
    private void DeleteButtons()
    {
        for (int i = 0;i < objects.Count; i++)
        {
            Destroy(objects[i]);
        }
    }
    private void SetSize()
    {
        float positionY = buttonRect.sizeDelta.y * (enemies.Length + spaceBetweenButtons + 1);
        content.sizeDelta = new Vector2(0, positionY / 2);
    }
}
