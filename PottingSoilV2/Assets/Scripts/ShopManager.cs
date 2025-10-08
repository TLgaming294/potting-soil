using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopView;

    public GameObject gameManager;
    public GameObject Content;
    public GameObject shopUpgradePrefab;

    public void Upgrade(int id)
    {
        switch (id)
        {
            case 1:
                gameManager.GetComponent<GameManager>().incrementSoilAddJa();
                break;
            default:
                Debug.Log("Invalid upgrade id");
                break;
        }

    }


    void Start()
    {
        Content = GameObject.Find("Content");
        shopView = GameObject.Find("ShopView");
        addExchangables();
        shopView.SetActive(false);
    }

    public void toggleShop()
    {
        shopView.SetActive(!shopView.activeSelf);
        unlockExchange(1);
    }



    public void unlockExchange(int id)
    {

        CurrencyExchange exchange = AllExchanges.exchangables.Find(x => x.id == id);
        if (exchange != null)
        { 
            GameObject exchangeObj = Instantiate(shopUpgradePrefab, Content.transform);
            exchangeObj.name = exchange.currencyExchangeName;
            exchangeObj.transform.Find("ItemName").GetComponent<TMP_Text>().text = exchange.currencyExchangeName;
            exchangeObj.transform.Find("Price").GetComponent<TMP_Text>().text = exchange.cost.ToString();
            exchangeObj.GetComponent<Button>().onClick.AddListener( () => Upgrade(id));
        }
        else
        {
            Debug.Log("Exchange not found");
        }

    }
    public class CurrencyExchange
    {
        public int id;
        public string currencyExchangeName;
        public int cost;
        public Sprite exchangeIcon;
        public Sprite costIcon;
    }

    public static class AllExchanges
    {
        public static List<CurrencyExchange> exchangables = new List<CurrencyExchange>();
    }

    public void addExchangables()
    { 
        AllExchanges.exchangables.Add(new CurrencyExchange { id = 1, currencyExchangeName = "Soil to Mulch", cost = 50 });
    }
}