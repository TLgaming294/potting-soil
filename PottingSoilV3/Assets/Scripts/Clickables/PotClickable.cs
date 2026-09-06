using UnityEngine;


public class PotClickable : MonoBehaviour, IClickable
{
	[SerializeField] private CurrencySO mulchConfig;
	[SerializeField] private CurrencySO soilConfig;

	public void OnClicked()
	{
		if (CurrencyManager.Instance.TryDeductCurrency(mulchConfig, 1))
		{
			CurrencyManager.Instance.AddCurrency(soilConfig, 2);
			Debug.Log("Converted 1 Mulch into 1 Soil!");
		}
		else
		{
			Debug.Log("Not enough Mulch!");
		}
	}

}
