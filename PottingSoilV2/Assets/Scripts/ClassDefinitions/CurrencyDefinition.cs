using System.Numerics;
using UnityEngine;

[System.Serializable]
public struct Currency
{
    public string ID; //e.g. "SOIL", "MULCH", etc.
    public string displayName;
    public Sprite icon;
    public int InitValue;

}
