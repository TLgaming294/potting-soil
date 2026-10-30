using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DudeStock
{
	public int Seeds;
	public List<LiveDude> Grown = new List<LiveDude>();
}
public class DudeManager : MonoBehaviour
{
	public static DudeManager Instance;
	private Dictionary<DudeSO, DudeStock> stock = new Dictionary<DudeSO, DudeStock>();
	private List<LiveDude> activeDudes = new List<LiveDude>();
	public event Action<DudeSO, DudeStock> OnStockChanged;
	void Awake()
	{
		if (Instance is null) { Instance = this; InitializeDudes(); } else Destroy(this);

	}
	void Start()
	{
		foreach (var dude in stock)
		{
			OnStockChanged?.Invoke(dude.Key, dude.Value);
		}
	}

	private void InitializeDudes()
	{
		stock.Clear();

		// Automatically loads every DudeSO in Resources/Dudes folder
		DudeSO[] loadedCurrencies = Resources.LoadAll<DudeSO>("Dudes");

		foreach (DudeSO config in loadedCurrencies)
		{
			stock[config] = new DudeStock();
		}
	}
	void Update()
	{

	}
	public void TickAllActive()
	{

	}
}
