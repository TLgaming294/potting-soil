using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public TMP_Text soilCounterText;
    public TMP_Text mulchCounterText;
    public GameObject unlockManager;

    private int soilCounter;

    public int soilAddJa;

    public int mulchCount;

    void Start()
    {
        soilAddJa = 2;
        mulchCount = 1;
        GameObject.Find("ShopButton").SetActive(false);
        unlockManager = GameObject.Find("UnlockManager");
        //unlockManager.GetComponent<NewBehaviourScript>().Unlock(1);
    }

    public void incrementSoilAddJa()
    {
        if(soilCounter<=0)
        {
            Debug.Log("insufficient Soil");
            return;
        }
        mulchCount++;
        soilCounter--;
    }

    public void click(string name)
    {


        if (name == "Pot")
        {
            if (mulchCount <= 0)
            {
                Debug.Log("insufficient Mulch");
            }
            else
            {

                soilCounter += soilAddJa;
                mulchCount--;
                
            }

        }
        

    }

    void Update()
    {
        soilCounterText.SetText(soilCounter.ToString());
        mulchCounterText.SetText(mulchCount.ToString());
    }

}
