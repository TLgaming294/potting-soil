using UnityEngine;
[CreateAssetMenu(menuName = "Data/Currency")]
public class CurrencySO : ScriptableObject
{
	public string displayName;
	public double startingAmount;

}

[System.Serializable]
public class LiveCurrency
{
	[field: SerializeField] public string CurrencyName { get; set; }
	[field: SerializeField] public double Amount { get; set; }

	public LiveCurrency(string name, double amount)
	{
		CurrencyName = name;
		Amount = amount;
	}
}


