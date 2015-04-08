using UnityEngine;
using System.Collections;

public class LoadStage1 : MonoBehaviour {
	
	public GameObject player;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (GetComponent<SaveLoadGameScript>().GetLoadComplete())
		//	RefreshVisualStage1();
	}
	
	public void RefreshVisualStage1() {
		if (player.GetComponent<PlayerBag>().IsCollected("204-key"))
			Destroy(GameObject.Find("Kunci 204"));
		if (player.GetComponent<PlayerBag>().IsCollected("302-key"))
			Destroy(GameObject.Find("Kunci 302"));
		if (player.GetComponent<PlayerBag>().IsCollected("exit-key"))
			Destroy(GameObject.Find("Brankas"));
		if (player.GetComponent<PlayerBag>().IsCollected("axe"))
			Destroy(GameObject.Find("axe"));
		if (SaveLoadGame.playerData.additionalData["Wood lock"] == "Removed")
			Destroy(GameObject.Find("Wood lock"));
		Destroy(gameObject.GetComponent<LoadStage1>());
	}
}
