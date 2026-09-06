using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilToMulchClickable : MonoBehaviour, IClickable
{
	[SerializeField] private CurrencySO soilConfig;
	[SerializeField] private CurrencySO mulchConfig;
	public void OnClicked()
	{
		Debug.Log("trying toconvert soil to mulch");
		if (CurrencyManager.Instance.TryDeductCurrency(soilConfig, 1))
		{
			CurrencyManager.Instance.AddCurrency(mulchConfig, 1);
		}
		else
		{
			Debug.Log("Not enough Soil!");
		}
	}
}
