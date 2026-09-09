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
			if (CurrencyManager.Instance.TryDeductCurrency(config.inputCurrency, liveData.CurrentInputAmount))
			{
				CurrencyManager.Instance.AddCurrency(config.outputCurrency, liveData.CurrentOutputAmount);
				return true;
			}
		}

		return false;
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
			liveData.InputMultiplier = Math.Max(1.0, newMultiplier);
			OnExchangeUpdated?.Invoke(config, liveData);
		}
	}
}
