using System;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeManager : MonoBehaviour
{
	public static ExchangeManager Instance;
	private Dictionary<ExchangeSO, LiveExchange> exchangeMap = new Dictionary<ExchangeSO, LiveExchange>();

	public event Action<ExchangeSO, LiveExchange> OnExchangeUpdated;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			InitializeExchanges();
		}
		else
		{
			Destroy(this);
		}
	}

	private void InitializeExchanges()
	{
		exchangeMap.Clear();
		ExchangeSO[] loadedExchanges = Resources.LoadAll<ExchangeSO>("Exchanges");

		foreach (ExchangeSO config in loadedExchanges)
		{
			if (config == null) continue;

			LiveExchange liveData = new LiveExchange(config);
			exchangeMap[config] = liveData;
		}

		Debug.Log($"ExchangeManager: {exchangeMap.Count} Exchanges aus Resources geladen.");
	}

	public bool TryExecuteExchange(ExchangeSO config)
	{
		if (config == null) return false;

		if (exchangeMap.TryGetValue(config, out LiveExchange liveData))
		{
			bool inputDeducted = DeductResource(config.inputCurrency, liveData.CurrentInputAmount);

			if (!inputDeducted) return false;

			AddResource(config.outputCurrency, liveData.CurrentOutputAmount);
			return true;
		}

		return false;
	}

	private bool DeductResource(ExchangableSO resource, double amount)
	{
		if (resource is CurrencySO currency)
		{
			// Compiler weiß hier sicher: 'currency' ist ein CurrencySO
			return CurrencyManager.Instance.TryDeductCurrency(currency, amount);
		}
		/*else if (resource is DudeSO dude)
		{
			// Falls du Dudes als Kosten opferst
			return DudeManager.Instance.TryKillDudes(dude, (int)amount);
		}*/

		return false;
	}

	private void AddResource(ExchangableSO resource, double amount)
	{
		if (resource is CurrencySO currency)
		{
			CurrencyManager.Instance.AddCurrency(currency, amount);
		}
		/*else if (resource is DudeSO dude)
		{
			for (int i = 0; i < (int)amount; i++)
			{
				DudeManager.Instance.AddDudeSeed(dude);
			}
		}*/
	}

	public LiveExchange GetLiveExchange(ExchangeSO config)
	{
		if (config != null && exchangeMap.TryGetValue(config, out LiveExchange liveData))
		{
			return liveData;
		}
		return null;
	}

	public void SetInputMultiplier(ExchangeSO config, double newMultiplier)
	{
		if (exchangeMap.TryGetValue(config, out LiveExchange liveData))
		{
			liveData.InputMultiplier = newMultiplier;
			OnExchangeUpdated?.Invoke(config, liveData);
		}
	}
}
