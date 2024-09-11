using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineModel 
{
    public int Bet { get; private set; } = 1000;

    public List<int> GetCombination()
    {
        List<int> result = new();
        for (int i = 0; i < 3; i++)
        {
            int random = Random.Range(0, 5);
            result.Add(random);
        }
        return result;
    }
    public void ChangeBet(int newAmount)
    {
        Bet = newAmount;
    }

    public int CheckCombination(List<int> combination)
    {
        int factor = 0;
        if (combination[0] == 0 && combination[1] == 0 && combination[2] == 0) factor = 5;
        if (combination[0] == 1 && combination[1] == 1 && combination[2] == 1) factor = 10;
        if (combination[0] == 2 && combination[1] == 2 && combination[2] == 2) factor = 20;
        if (combination[0] == 3 && combination[1] == 3 && combination[2] == 3) factor = 50;
        if (combination[0] == 4 && combination[1] == 4 && combination[2] == 4) factor = 100;
        return factor * Bet;
    }
}
