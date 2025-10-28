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
    private Vector2Int amount;

    public Currency(int initialAmount, int initialEValue)
    {
        amount = new Vector2Int(initialAmount, initialEValue);
    }

    public Vector2Int GetAmount()
    {
        return amount;
    }

    public void AddAmount(int value, int eValue)
    {
        amount.x += value;
        amount.y += eValue;
    }

    public bool SpendAmount(int value, int eValue)
    {
        return true;
        }

    

}