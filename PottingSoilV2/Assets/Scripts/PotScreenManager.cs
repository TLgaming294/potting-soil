using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Psoil.Economy;

public class PotScreenManager : MonoBehaviour
{
    public CurrencyManager currencyManager;

    public void Start()
    {
        
    }


    public void click(string name)
    {
        if (name == "Pot")
        {
            if ( currencyManager.GetCurrency("MULCH") <= 0)
            {
                Debug.Log("insufficient Mulch");
            }
            else
            {
                currencyManager.AddCurrency("MULCH", -1);
                currencyManager.AddCurrency("SOIL", 2);
            }

        }
    }
}
