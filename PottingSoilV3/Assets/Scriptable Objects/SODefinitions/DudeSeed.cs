using UnityEngine;

[CreateAssetMenu(menuName = "Objects/Dude Seed")]
[System.Serializable]
public class DudeSeed : ScriptableObject
{
	[field: SerializeField] public string DudeName { get; set; }
	[field: SerializeField] public double Cost { get; set; }
	[field: SerializeField] public CurrencySO Currency { get; set; }
	[field: SerializeField] public float GrowthTime { get; set; }
	[field: SerializeField] public float TimeToLive { get; set; }
	[field: SerializeField] public Sprite DudeSprite { get; set; }
	[field: SerializeField] public double DudeSoulsAmount { get; set; }

}


