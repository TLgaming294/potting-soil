using System.Numerics;
using UnityEngine;

[System.Serializable]
public class Exchange
{
    public string ID; //e.g. "SOIL_TO_MULCH", etc.
    public string FromCurrencyID;
    public string ToCurrencyID;
    public BigInteger FromAmount; // e.g 1 means from 1 to n currency
    public BigInteger ToAmount; // e.g. 2 means n FromAmount gives 2 ToAmount
    public int initFromAmount; //initial values for setting up exchanges
    public int initToAmount;

    public Exchange(string id, string fromCurrencyID, string toCurrencyID, BigInteger fromAmount, BigInteger exchangeRate)
    {
        ID = id;
        FromCurrencyID = fromCurrencyID;
        ToCurrencyID = toCurrencyID;
        FromAmount = fromAmount;
        ToAmount = exchangeRate;
    }

    public Exchange(string id, string fromCurrencyID, string toCurrencyID)
    {
        ID = id;
        FromCurrencyID = fromCurrencyID;
        ToCurrencyID = toCurrencyID;
        FromAmount = initFromAmount;
        ToAmount = initToAmount;
    }

}
