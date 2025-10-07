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

    public void Upgrade1()
    {
        gameManager.GetComponent<GameManager>().incrementSoilAddJa();
        
    }


    void Start()
    {
        Content = GameObject.Find("Content");
        shopView = GameObject.Find("ShopView");
        shopView.SetActive(false);
    }

    public void toggleShop()
    {
        shopView.SetActive(!shopView.activeSelf);
        unlockUpgrade();
    }

    public class Upgrade
    {
        public int id;
        public string upgradeName;
        public int cost;
        public Sprite upgradeIcon;
        public Sprite costIcon;
    }

    public void unlockUpgrade()
    {
        Upgrade upgrade1 = new Upgrade();
        upgrade1.id = 1;
        upgrade1.upgradeName = "Soil +1 Ja";
        upgrade1.cost = 50;
        upgrade1.upgradeIcon = Resources.Load<Sprite>("Icons/soil_icon");
        upgrade1.costIcon = Resources.Load<Sprite>("Icons/ja_icon");

        GameObject upgradeObj1 = Instantiate(shopUpgradePrefab, Content.transform);
        upgradeObj1.transform.Find("ItemName").GetComponent<TMP_Text>().text = upgrade1.upgradeName;
        upgradeObj1.transform.Find("Price").GetComponent<TMP_Text>().text = upgrade1.cost.ToString();
        //upgradeObj1.transform.Find("Image").GetComponent<UnityEngine.UI.Image>().sprite = upgrade1.upgradeIcon;
        //upgradeObj1.transform.Find("PriceImage").GetComponent<UnityEngine.UI.Image>().sprite = upgrade1.costIcon;
        upgradeObj1.transform.SetParent(Content.transform, false);
        upgradeObj1.GetComponent<Button>().onClick.AddListener(Upgrade1);
    }

}
