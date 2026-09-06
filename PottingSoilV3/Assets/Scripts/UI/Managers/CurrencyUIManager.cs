using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyUIManager : MonoBehaviour
{
	private Dictionary<CurrencySO, LiveCurrency> allCurrencies;
	private GameObject currencyContent;
	[SerializeField] private GameObject CurrencyViewPrefab;
	void Start()
	{
		currencyContent = UIManager.Instance.CurrencyContent;
		allCurrencies = CurrencyManager.Instance.GetAllCurrencies();
		foreach (CurrencySO cur in allCurrencies.Keys)
		{
			GameObject pre = Instantiate(CurrencyViewPrefab, currencyContent.transform);
			pre.gameObject.GetComponent<CurrencyViewUI>().Setup(cur);
		}
	}
}
