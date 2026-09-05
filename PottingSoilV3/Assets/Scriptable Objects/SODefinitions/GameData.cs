using System.Collections.Generic;
using UnityEngine;
public class GameData
{
	[field: SerializeField] public List<LiveCurrency> SavedCurrencies { get; set; } = new List<LiveCurrency>();

}
