using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerBag : MonoBehaviour {
	
	public Hashtable playerBag;
	public Hashtable playerAdditionalData;
	public bool isBlindMode;
	public GameObject[] hudListItems;
	
	void Awake () {
		playerBag = new Hashtable();
		playerAdditionalData = new Hashtable();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate() {
		RefreshVisual();
	}
	
	void RefreshVisual() {
		if (isBlindMode == false) {
			for(int i=0;i<hudListItems.Length;i++) {
				string name = hudListItems[i].name;
				if (playerBag.Contains(name) == true) {
					hudListItems[i].GetComponent<Image>().color = new Color(1, 1, 1, 0.85f);
				}
			}
		}
	}
	
	public bool IsCollected(string item) {
		return playerBag.ContainsKey(item);
	}
	
	public void Collecting(string item) {
		playerBag[item] = true;
	}
}
