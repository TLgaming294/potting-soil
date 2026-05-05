using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exchange : ScriptableObject
{
    [field:SerializeField] public Currency CurrencyFrom{get;set;}
    [field:SerializeField] public Currency CurrencyTo{get;set;}
    [field:SerializeField] public int amountFromTo{get;set;}
    [field:SerializeField] public float multiplyer{get;set;}

    public void convert(int amount)
    {
        
    }

}
