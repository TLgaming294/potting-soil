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
	public event Action<DudeSO> OnStockChanged;
	void Awake()
	{
		if (Instance is null) Instance = this; else Destroy(this);

	}
}
