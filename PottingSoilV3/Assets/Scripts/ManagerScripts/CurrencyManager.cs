using System;
using UnityEngine;
using System.Collections.Generic;

public class CurrencyManager : MonoBehaviour
{
	public static CurrencyManager Instance;
	[SerializeField] private Dictionary<CurrencySO, LiveCurrency> currencyDict = new Dictionary<CurrencySO, LiveCurrency>();

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			InitializeCurrencies();
		}
		else
		{
			Destroy(this);
		}
	}

	private void InitializeCurrencies()
	{
		currencyDict.Clear();

		// Automatically loads every CurrencySO in Resources/Currencies folder
		CurrencySO[] loadedCurrencies = Resources.LoadAll<CurrencySO>("Currencies");

		foreach (CurrencySO config in loadedCurrencies)
		{
			currencyDict[config] = new LiveCurrency(config.displayName, config.startingAmount);
		}
	}

	public bool TryDeductCurrency(CurrencySO currency, double amount)
	{
		if (currency == null) return false;
		amount = System.Math.Abs(amount);

		if (currencyDict.TryGetValue(currency, out LiveCurrency liveData))
		{
			if (liveData.Amount >= amount)
			{
				liveData.Amount -= amount;
				Debug.Log($"Deducted {amount} {currency.displayName}. Remaining: {liveData.Amount}");
				return true;
			}
		}

		Debug.Log($"Insufficient {currency.displayName}!");
		return false;
	}

	public void AddCurrency(CurrencySO currency, double amount)
	{
		if (currency == null) return;
		amount = System.Math.Abs(amount);

		if (currencyDict.TryGetValue(currency, out LiveCurrency liveData))
		{
			liveData.Amount += amount;
			Debug.Log($"Added {amount} {currency.displayName}. Total: {liveData.Amount}");
		}
	}

	public double GetAmount(CurrencySO currency)
	{
		if (currencyDict.TryGetValue(currency, out LiveCurrency liveData))
		{
			return liveData.Amount;
		}
		return 0;
	}
}
