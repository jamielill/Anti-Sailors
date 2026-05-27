using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemSingletone : MonoBehaviour
{

	public static EventSystemSingletone singletonInstance;
	
	private void Awake() 
	{ 
		if (singletonInstance != null) 
		{ 
			Destroy(this.gameObject); 
		} 
		else 
		{ 
			singletonInstance = this; 
		} 
	}
}
