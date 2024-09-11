using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhettoSimulation 
{
    private string[] actions = { "������ ����� � �����:", "��������� � ��������� � �����:", "��������� � ��������� � �����:" };
    private List<string> allies = new List<string>();
    private ChatActions chatActions = new();
    private GhettoState state;

    private EnemyDataFinder enemyDataFinder;

    public GhettoSimulation(GhettoState ghettoState)
    {
        state = ghettoState;
    }
    public IEnumerator GhettoTimer()
    {
        enemyDataFinder = new();
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(30, 60));
            SimulateAction();
        }
    }
    private void SimulateAction()
    {
        var stateData = state.GetState();
        if (stateData != null)
        {
            var enemyData = enemyDataFinder.FindByName(stateData.EnemyName);
            if (stateData.CurrentHealth > enemyData.MaxHealth / 3)
            {
                int randomDamage = Random.Range(10, enemyData.MaxHealth / 20);
                string randomName = chatActions.GetPlayerName();
                if (!allies.Contains(randomName))
                {
                    allies.Add(randomName);
                    stateData.ChatMessages.Add($"�����: {randomName} �������������.");
                }
                stateData.ChatMessages.Add($"{randomName} {actions[Random.Range(0, actions.Length)]} <color=green>{randomDamage}</color> �����.");
                stateData.CurrentHealth -= randomDamage;
            }
            else
            {
                if (allies.Count != 0)
                {
                    stateData.ChatMessages.Add($"{allies[allies.Count - 1]} ������!");
                    allies.RemoveAt(allies.Count - 1);
                }
                else return;
            }
            state.SaveState();
            state.UpdateView();
        }
    }

}
