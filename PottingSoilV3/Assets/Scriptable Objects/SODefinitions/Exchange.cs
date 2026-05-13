using UnityEngine;

[CreateAssetMenu(menuName = "Objects/Exchange")]
public class Exchange : ScriptableObject
{
	[field: SerializeField] public CurrencySO CurrencyFrom { get; set; }
	[field: SerializeField] public CurrencySO CurrencyTo { get; set; }
	[field: SerializeField] public GameData data { get; set; }

	[field: SerializeField] public double amountFrom { get; set; }
	[field: SerializeField] public double amountTo { get; set; }
	[field: SerializeField] public double multiplyer { get; set; } = 1;

	public void convert(double amountToConvert)
	{
		if (CurrencyManager.Instance.TryChangeCurrency(CurrencyFrom.CurrencyType, -amountFrom * amountToConvert))
		{
			CurrencyManager.Instance.TryChangeCurrency(CurrencyTo.CurrencyType, amountTo * multiplyer * amountToConvert);
		}
	}

}
