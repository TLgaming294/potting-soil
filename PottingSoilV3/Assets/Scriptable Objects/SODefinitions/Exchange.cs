using UnityEngine;

[CreateAssetMenu(menuName = "Objects/Exchange")]
public class Exchange : ScriptableObject
{
	[field: SerializeField] public CurrencyType CurrencyFrom { get; set; }
	[field: SerializeField] public CurrencyType CurrencyTo { get; set; }
	[field: SerializeField] public GameData data { get; set; }

	[field: SerializeField] public double amountFrom { get; set; }
	[field: SerializeField] public double amountTo { get; set; }
	[field: SerializeField] public double multiplyer { get; set; } = 1;

	public void convert(double amountToConvert)
	{
		if (data.TryChangeCurrency(CurrencyFrom, -amountFrom * amountToConvert))
		{
			data.TryChangeCurrency(CurrencyTo, amountTo * multiplyer * amountToConvert);
		}
	}

}
