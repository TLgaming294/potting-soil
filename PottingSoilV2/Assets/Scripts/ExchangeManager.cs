using System.Collections;
using System.Collections.Generic;
using Psoil.Economy;
using UnityEngine;

public class ExchangeManager : MonoBehaviour
{
    public List<Exchange> exchanges = new List<Exchange>();
    public ExchangeListSO exchangeDefinitions;
    public CurrencyManager currencyManager = CurrencyManager.Instance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    void Awake()
    {
        InitExchanges();
    }
    void InitExchanges()
    {
        foreach (var def in exchangeDefinitions.allExchanges)
        {
            def.FromAmount = def.initFromAmount;
            def.ToAmount = def.initToAmount;
            exchanges.Add(def);
            Debug.Log("Added exchange: " + def.ID);
            Debug.Log("From " + def.FromCurrencyID + " to " + def.ToCurrencyID + " at rate " + def.FromAmount + " to " + def.ToAmount);
        }
    }

    public void ExecuteExchange(string id)
    {
        Exchange exchange = exchanges.Find(e => e.ID == id);
        if (exchange == null)
        {
            Debug.LogError($"Exchange with ID '{id}' not found.");
            return;
        }
        if (currencyManager.GetCurrency(exchange.FromCurrencyID) < exchange.FromAmount)
        {
            Debug.LogError($"Not enough currency '{exchange.FromCurrencyID}' to perform the exchange.");
            return;
        }
        currencyManager.AddCurrency(exchange.FromCurrencyID, -exchange.FromAmount);
        currencyManager.AddCurrency(exchange.ToCurrencyID, exchange.ToAmount);
    }
}
