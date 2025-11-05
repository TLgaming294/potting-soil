using UnityEngine;
using System.Numerics;
using System.Collections.Generic;
namespace Psoil.Economy
{
[CreateAssetMenu(fileName = "ExchangeData", menuName = "Game Data/Exchange list")]
public class ExchangeListSO : ScriptableObject
{
    public List<Exchange> allExchanges = new List<Exchange>();

    public Exchange GetCurrency(string id)
    {
        return allExchanges.Find(e => e.ID == id);
    }
}
}
