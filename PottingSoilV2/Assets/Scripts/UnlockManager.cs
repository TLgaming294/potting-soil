using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    public GameObject shopButton;
    public List<Unlock> unlocks = new List<Unlock>();

    void Start()
    {

        unlocks.Add(new Unlock(1, "Shop", false));
        Unlock(1);

    }

    
    public void Unlock(int id)
    {
        unlocks.Find(x => x.getId() == id).setIsUnlocked(true);

        UpdateUnlocks();
    }

    [ContextMenu("Update Unlocks")]
    void UpdateUnlocks()
    {
        foreach (Unlock unlock in unlocks)
        {
                switch (unlock.getId())
                {
                    case 1:
                        shopButton.SetActive(unlock.getIsUnlocked());
                        break;
                    // case 2:
                    //     GameObject.Find("Level2").SetActive(true);
                    //     break;
                    default:
                        Debug.Log("Invalid unlock id");
                        break;
                }
        }
    }
}

    


[System.Serializable]
public class Unlock
{
    public Unlock(int id, string name, bool isUnlocked)
    {
        this.id = id;
        this.name = name;
        this.isUnlocked = isUnlocked;
    }
    public int id;
    string name;
    public bool isUnlocked;

    public int getId()
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

