using UnityEngine;


public class ExchangeClickable : MonoBehaviour, IClickable
{
	[SerializeField] private ExchangeSO exchange;

	public void OnClicked()
	{
		ExchangeManager.Instance.TryExecuteExchange(exchange);
	}

}
