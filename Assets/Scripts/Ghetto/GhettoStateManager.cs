using UnityEngine;

public class GhettoStateManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyListPanel;
    [SerializeField] private GameObject fightPanel;
    [SerializeField] private GameObject prisePanel;
    [SerializeField] private DamageButtons damageButtons;
    private GhettoState state = new();
    private GhettoStatsData stats = new();
    private Wallet wallet = new();
    private EnemyDataFinder enemyFinder;

    private void Start()
    {
        enemyFinder = new();
        damageButtons.OnEndHealth += WiningFight;
        if (state.GetState() != null)
        {
            TabController(false, true);
            state.UpdateView();
        }
        else
        {
            TabController(true, false);
        }
    }
    public void StartFight(SoEnemiesData data)
    {
        TabController(false, true);
        state = new GhettoState(data);
    }
    public void LeaveFight()
    {
        TabController(true, false);
        state.ClearEnemy();
    }
    private void WiningFight()
    {
        prisePanel.SetActive(true);
        prisePanel.TryGetComponent(out GhettoPriseVisual visul);
        SoEnemiesData enemy = enemyFinder.FindByName(state.GetState().EnemyName);
        SoAccessory accessory = GetPrise(enemy);
        visul.SetData(enemy, accessory);
        wallet.MoneyOperation(enemy.Reward);
        wallet.RespectsOperation(enemy.RespectReward);
        if(accessory != null) stats.AddNewAccessory(accessory);
        LeaveFight();
    }
    private void TabController(bool listTab, bool fightTab)
    {
        enemyListPanel.SetActive(listTab);
        fightPanel.SetActive(fightTab);
    }
    private SoAccessory GetPrise(SoEnemiesData data)
    {
        int random = Random.Range(1, 101);
        SlotRarity slot;
        if (random > 90) slot = SlotRarity.MainDrop;
        else if (random > 70) slot = SlotRarity.VeryRare;
        else if (random > 50) slot = SlotRarity.Rare;
        else slot = SlotRarity.Usual;

        for (int i = 0; i < data.Accessories.Count; i++)
        {
            if(data.Accessories[i].Rarity == slot)
            {
                if (!stats.IsContains(data.Accessories[i]))
                {
                    return data.Accessories[i];
                }
            }
        }
        for (int i = 0; i < data.Accessories.Count; i++)
        {
            if (data.Accessories[i].Rarity == SlotRarity.Usual)
            {
                if (!stats.IsContains(data.Accessories[i]))
                {
                    return data.Accessories[i];
                }
            }
        }
        return null;
    }
}
