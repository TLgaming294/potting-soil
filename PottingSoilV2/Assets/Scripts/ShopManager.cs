using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Psoil.Economy
{
    public class ShopManager : MonoBehaviour
    {
        void Start()
        {
        }
 
        public GameObject shopView;

        public void toggleShop()
        {
            Debug.Log("Toggling Shop View");
            shopView.SetActive(!shopView.activeSelf);
        }

    }
}