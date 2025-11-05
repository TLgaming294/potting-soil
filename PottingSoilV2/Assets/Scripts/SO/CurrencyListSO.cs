using UnityEngine;
using System.Numerics;
using System.Collections.Generic;
namespace Psoil.Economy
{
[CreateAssetMenu(fileName = "CurrenciesData", menuName = "Game Data/Currencies list")]
public class CurrencyListSO : ScriptableObject
{
    public List<Currency> allCurrencies = new List<Currency>();

    public Currency GetCurrency(string id)
    {
        return allCurrencies.Find(c => c.ID == id);
    }
}
}

