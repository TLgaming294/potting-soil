using UnityEngine;

[CreateAssetMenu(menuName = "Data/Exchange")]
public class ExchangeSO : ScriptableObject
{
	public CurrencySO inputCurrency;
	public CurrencySO outputCurrency;
	public double baseInputAmount;
	public double baseOutputAmount;
}

[System.Serializable]
public class LiveExchange
{
	public ExchangeSO Config { get; private set; }
	public int Level { get; set; } = 1;
	public double InputMultiplier { get; set; } = 1.0;
	public double OutputMultiplier { get; set; } = 1.0;

	public LiveExchange(ExchangeSO config)
	{
		Config = config;
	}
	public double CurrentInputAmount => Config.baseInputAmount * InputMultiplier;

	public double CurrentOutputAmount => Config.baseOutputAmount * OutputMultiplier * InputMultiplier;
}
