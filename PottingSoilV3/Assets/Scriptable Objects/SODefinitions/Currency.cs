using UnityEngine;

public class CurrencySO : ScriptableObject
{
	[field: SerializeField] public string CurrencyType { get; set; }

}

[System.Serializable]
public class LiveCurrency
{
	[field: SerializeField] public string CurrencyType { get; set; }
	[field: SerializeField] public double Amount { get; set; }

	public LiveCurrency(string type, double amount)
	{
		CurrencyType = type;
		Amount = amount;
	}
}


