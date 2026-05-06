using UnityEngine;

public enum CurrencyType
{
	Soil,
	Mulch,
	Croins,
	DudeSouls

}

[System.Serializable]
public class Currency
{
	[field: SerializeField] public CurrencyType CurrencyType { get; set; }
	[field: SerializeField] public double Amount { get; set; }

	public Currency(CurrencyType type, double amount)
	{
		CurrencyType = type;
		Amount = amount;
	}
}


