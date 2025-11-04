using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Numerics;

public class CurrencyManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}

public class Currency
{
    public BigInteger value;

    public string toMantissaView()
    {
        string raw = value.ToString();
        if (raw.Length > 3)
        {
            int exponent = raw.Length - 1;
            double mantissa = double.Parse(raw.Substring(0, 4)) / 1000.0;
            string display = $"{mantissa:F2}e{exponent}";
            return display;

        }
        return "Null";
    }

    

}