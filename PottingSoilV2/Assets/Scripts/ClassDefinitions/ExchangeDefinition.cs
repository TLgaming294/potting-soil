using System.Numerics;
using UnityEngine;

[System.Serializable]
public class Exchange
{
    public string ID; //e.g. "SOIL_TO_MULCH", etc.
    public string FromCurrencyID;
    public string ToCurrencyID;
    public BigInteger FromAmount = 1; // e.g 1 means from 1 to n currency
    public BigInteger ToAmount = 2; // e.g. 2 means n FromAmount gives 2 ToAmount

    public Exchange(string id, string fromCurrencyID, string toCurrencyID, BigInteger fromAmount, BigInteger exchangeRate)
    {
        ID = id;
        FromCurrencyID = fromCurrencyID;
        ToCurrencyID = toCurrencyID;
        FromAmount = fromAmount;
        ToAmount = exchangeRate;
    }

}
