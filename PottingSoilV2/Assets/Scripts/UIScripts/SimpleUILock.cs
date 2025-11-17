using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Psoil.Economy;
public class SimpleUILock : MonoBehaviour
{
    public string idToListenTo;
    void OnEnable()
    {
        UnlockManager.OnUnlockChanged += HandleUnlockChanged;
    }
    void OnDisable()
    {
        UnlockManager.OnUnlockChanged -= HandleUnlockChanged;
    }
    void HandleUnlockChanged(string id,  bool isUnlocked)
    {
        if (id == idToListenTo)
        {
            gameObject.SetActive(isUnlocked);
        }
    }
}
