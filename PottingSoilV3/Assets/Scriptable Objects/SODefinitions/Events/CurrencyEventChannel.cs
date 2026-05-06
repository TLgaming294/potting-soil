using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Events/Currency Event Channel")]
public class CurrencyEventChannel : ScriptableObject
{
	public event Action<Currency> OnEventRaised;

	public void RaiseEvent(Currency value)
	{
		OnEventRaised?.Invoke(value);
	}
}
