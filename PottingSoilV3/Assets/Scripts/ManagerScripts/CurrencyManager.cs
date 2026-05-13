using System;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
	public static CurrencyManager Instance;

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(this);
		}
	}

	public bool TryChangeCurrency(string type, double amount)
	{
		LiveCurrency currencyToChange = GameManager.gameDataInstance.LiveCurrencies.Find(c => c.CurrencyType == type);

		if (currencyToChange == null) return false;
		if (currencyToChange.Amount < Math.Abs(amount)) return false;

		if (amount < 0)
		{
			currencyToChange.Amount -= amount;
			return true;
		}

		currencyToChange.Amount += amount;
		return true;
	}
}
