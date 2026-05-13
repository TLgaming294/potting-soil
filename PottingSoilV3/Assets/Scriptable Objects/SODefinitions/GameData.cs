using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/Game Data")]
public class GameData : ScriptableObject
{
	[field: SerializeField] public List<LiveCurrency> LiveCurrencies { get; set; } = new List<LiveCurrency>();

}
