using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerData { 
	
	public Hashtable playerBag;
	public Hashtable additionalData;
	
	public PlayerData() {
		playerBag = new Hashtable();
		additionalData = new Hashtable();
	}
}
