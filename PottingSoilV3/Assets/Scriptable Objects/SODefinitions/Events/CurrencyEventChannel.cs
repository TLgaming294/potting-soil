using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Events/Currency Event Channel")]
public class CurrencyEventChannel : ScriptableObject
{
	public event Action<LiveCurrency> OnEventRaised;

	public void RaiseEvent(LiveCurrency value)
	{
		OnEventRaised?.Invoke(value);
	}
}
