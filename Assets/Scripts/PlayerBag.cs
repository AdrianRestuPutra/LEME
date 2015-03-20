using UnityEngine;
using System.Collections;

public class PlayerBag : MonoBehaviour {
	
	Hashtable playerBag;
	ArrayList arrayList;
	
	
	void Awake () {
		playerBag = new Hashtable();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public bool IsCollected(string item) {
		return playerBag.ContainsKey(item);
	}
	
	public void Collecting(string item) {
		playerBag[item] = true;
	}
}
