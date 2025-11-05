using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Numerics;
using UnityEngine.UIElements.Experimental;
using System;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }
    public static event Action<string, BigInteger> OnCurrencyAmountChanged;
    public CurrencyListSO currencyDefinitions;
    protected Dictionary<string, BigInteger> currencyAmounts = new Dictionary<string, BigInteger>();

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitCurrencies();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitCurrencies()
    {
        currencyAmounts.Clear();
        foreach (var def in currencyDefinitions.allCurrencies)
        {
            currencyAmounts.Add(def.ID, def.InitValue);
        }
    }

    public void AddCurrency(string currencyID, BigInteger amount)
    {
        Debug.Log("event started");
        if (currencyAmounts.ContainsKey(currencyID))
        {
            currencyAmounts[currencyID] += amount;
            CurrencyManager.OnCurrencyAmountChanged?.Invoke(currencyID, currencyAmounts[currencyID]);
        }
        else
        {
            Debug.LogError($"Currency ID '{currencyID}' not found for addition.");
        }
    }

    public BigInteger GetCurrency(string currencyID)
    {
        if (currencyAmounts.ContainsKey(currencyID))
        {
            return currencyAmounts[currencyID];
        }
        else
        {
            return 0;
        }
    }

}


