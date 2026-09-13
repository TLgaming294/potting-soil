using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Data/Dude")]
public class DudeSO : ExchangableSO
{
	[Header("Time")]
	public int lifetime; //in work cycles
	public float growTime; //in seconds
	public float workInterval; // in seconds

	[Header("Cost")]
	public CurrencySO costCurrency;
	public double currencyAmount;

}

public enum DudeState
{
	Growing,
	Working,
	Dead
}

[System.Serializable]
public class LiveDude
{
	public DudeSO Config { get; private set; }
	public DudeState State { get; private set; } = DudeState.Growing;

	private float timer;
	public int RemainingLifetime { get; private set; }
	public ExchangeSO job;

	// Event, damit z. B. die UI oder das 3D-Modell weiß, wenn der Dude wächst, arbeitet oder stirbt
	public event Action<LiveDude> OnStateChanged;
	public event Action<LiveDude> OnTickExecuted;

	public LiveDude(DudeSO config)
	{
		Config = config;
		RemainingLifetime = config.lifetime;
	}

	public void Tick(float deltaTime)
	{
		if (State == DudeState.Dead) return;

		timer += deltaTime;

		if (State == DudeState.Growing)
		{
			if (timer >= Config.growTime)
			{
				timer = 0; // Restzeit mitnehmen
				State = DudeState.Working;
				OnStateChanged?.Invoke(this);
			}
			return;
		}

		if (State == DudeState.Working)
		{
			if (timer >= Config.workInterval)
			{
				timer -= Config.workInterval;
				Work();
			}
		}
	}

	private void Work()
	{
		bool success = ExchangeManager.Instance.TryExecuteExchange(job);

		if (success)
		{
			RemainingLifetime--;
			OnTickExecuted?.Invoke(this);

			if (RemainingLifetime <= 0)
			{
				State = DudeState.Dead;
				OnStateChanged?.Invoke(this);
			}
		}
	}
}
