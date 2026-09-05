using UnityEngine;

[CreateAssetMenu(menuName = "Objects/Exchange")]
public class Exchange : ScriptableObject
{
	public CurrencySO currencyFrom;
	public CurrencySO currencyTo;
	public double baseAmountFrom;
	public double baseAmountTo;
	public double multiplyer = 1;

}
