using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestClickableScript : MonoBehaviour, IClickable
{
	public void OnClicked()
	{
		Debug.Log("CLicked the box");
	}


}
