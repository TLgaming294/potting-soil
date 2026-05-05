using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Game Data")]
public class GameData : ScriptableObject
{
    List<Currency> currencies = new List<Currency>();

    public bool TryChangeCurrency(CurrencyType type, double amount)
    {
        Currency data = currencies.Find(c => c.CurrencyType == type);

        if (data == null) return false;
        if (data.Amount< Math.Abs(amount)) return false;

        if (amount < 0)
        {
            data.Amount -= amount;
            return true;
        }
        
        data.Amount += amount;
        return true;
    }

}
