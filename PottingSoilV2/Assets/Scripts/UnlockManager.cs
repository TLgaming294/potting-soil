using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

namespace Psoil.Economy
{
    public class UnlockManager : MonoBehaviour
    {
        public static event Action<string, bool> OnUnlockChanged;
        public GameObject shopButton;
        public List<Unlock> unlocks = new List<Unlock>();

        void Start()
        {

            unlocks.Add(new Unlock("SHOP_BUTTON", "Shop", false));
            Unlock("SHOP_BUTTON");

        }


        public void Unlock(string id)
        {
            unlocks.Find(x => x.getId() == id).setIsUnlocked(true);
            OnUnlockChanged?.Invoke(id, true);
            UpdateUnlocks();
        }

        [ContextMenu("Update Unlocks")]
        void UpdateUnlocks()
        {
            foreach (Unlock unlock in unlocks)
            {
                OnUnlockChanged?.Invoke(unlock.id.ToString(), unlock.getIsUnlocked());
            }
        }
    }




    [System.Serializable]
    public class Unlock
    {
        public Unlock(string id, string name, bool isUnlocked)
        {
            this.id = id;
            this.name = name;
            this.isUnlocked = isUnlocked;
        }
        public string id;
        string name;
        public bool isUnlocked;

        public string getId()
        {
            return this.id;
        }
        public bool getIsUnlocked()
        {
            return this.isUnlocked;
        }
        public void setIsUnlocked(bool isUnlocked)
        {
            this.isUnlocked = isUnlocked;
        }
    }

}