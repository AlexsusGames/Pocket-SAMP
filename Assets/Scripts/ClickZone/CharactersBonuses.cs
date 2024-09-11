using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CharactersBonuses 
{
    private float sellFactor;
    private float buyFactor;
    public int CalculateSellSale(int price)
    {
        CaluclateFactor();
        return CalculatePrice(price, sellFactor);
    }
    public int CalculateBuySale(int price)
    {
        CaluclateFactor();
        return CalculatePrice(price, buyFactor);
    }
    private void CaluclateFactor()
    {
        int skinIndex = PlayerPrefs.GetInt("Avatar");
        switch (skinIndex)
        {
            default: sellFactor = 1; buyFactor = 1; break;
            case 7: sellFactor = 1.2f; buyFactor = 1; break;
            case 8: sellFactor = 1.2f; buyFactor = 0.9f; break;
            case 9: sellFactor = 1.2f; buyFactor = 0.9f; break;
            case 10: sellFactor = 1.2f; buyFactor = 0.8f; break;
        }
    }
    private int CalculatePrice(int price, float factor)
    {
        float sale;
        if (sellFactor != 0)
            sale = price - price / factor;
        else sale = 0;
        int result = price + (int)sale;
        return result;
    }
    public bool IsDoubleChanceCraft()
    {
        if (PlayerPrefs.GetInt("Avatar") > 8) return true;
        else return false;
    }
}
