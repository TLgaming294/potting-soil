using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameData GameDataPreset { get; set; }
	public static GameData gameDataInstance;
	public static GameManager Instance;

	void Awake()
	{
		if (Instance == null)
		{
			gameDataInstance = new GameData();
			Instance = this;
		}
		else
		{
			Destroy(this);
		}
	}


}
