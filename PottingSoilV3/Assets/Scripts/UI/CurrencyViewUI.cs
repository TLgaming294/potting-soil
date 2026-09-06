using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyViewUI : MonoBehaviour
{
	[SerializeField] private TMP_Text displayName;
	[SerializeField] private TMP_Text value;
	private CurrencySO CurrencyConfig;

	void OnEnable()
	{
		CurrencyManager.OnCurrencyChanged += HandleCurrencyChanged;
	}
	void OnDisable()
	{
		CurrencyManager.OnCurrencyChanged -= HandleCurrencyChanged;
	}

	public void Setup(CurrencySO config)
	{
		CurrencyConfig = config;

		if (displayName != null)
			displayName.text = config.displayName;

		/*if (iconImage != null && config.Icon != null)
            iconImage.sprite = config.Icon;*/
	}

	private void HandleCurrencyChanged(CurrencySO changedCurrency, double newAmount)
	{
		if (changedCurrency == CurrencyConfig)
		{
			UpdateAmount(newAmount);
		}
	}

	public void UpdateAmount(double newAmount)
	{
		// Formats large numbers cleanly (e.g., 10, 100, 1.5K)
		value.text = newAmount.ToString("N0");
	}
}
