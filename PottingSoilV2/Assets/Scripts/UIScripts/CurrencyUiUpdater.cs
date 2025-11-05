using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class CurrencyUiUpdater : MonoBehaviour
{
    public string IDToTrack = "";
    [SerializeField] private float updateInterval = 0.1f;
    public TextMeshProUGUI currencyValue;
    private BigInteger latestAmount;
    private float timer = 0f;

    void Start()
    {
        currencyValue = GetComponentInChildren<TextMeshProUGUI>();
        if (currencyValue == null)
    {
        Debug.LogError("TextMeshProUGUI component not found in children! Check your prefab structure.");
        // Stop execution if the essential component is missing
        enabled = false; 
        return;
    }
        CurrencyManager.OnCurrencyAmountChanged += OnCurrencyChanged; //subscribe to event
        if (CurrencyManager.Instance != null)
        {
            latestAmount = CurrencyManager.Instance.GetCurrency(IDToTrack);
            UpdateText(latestAmount);
        }
    }
    private void OnDestroy()
    {
        CurrencyManager.OnCurrencyAmountChanged -= OnCurrencyChanged; //unsubscribe to prevent memory leaks
    }
    private void OnCurrencyChanged(string id, BigInteger newAmount)
    {
        Debug.Log("event ended with " + id + " "+newAmount.ToString());
        if (id == IDToTrack)
        {
            latestAmount = newAmount;
        }
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= updateInterval)
        {
            Debug.Log($"[{IDToTrack}] Throttle hit. Running UpdateText with value: {latestAmount}");
            UpdateText(latestAmount);
            timer = 0f; // Reset the timer
        }
    }

    private void UpdateText(BigInteger amount)
    {
        if (amount >= 1000000000)
        {
            // Example conversion: 1234567890 -> 1.23e9
            double log10 = BigInteger.Log10(amount);
            int exponent = (int)Math.Floor(log10);
            double mantissa = (double)amount / Math.Pow(10, exponent);
            
            currencyValue.text = $"{mantissa:F2}e{exponent}";
        }
        else
        {
             // For smaller numbers, just show the full amount
            currencyValue.text = amount.ToString();
        }
    }


}
