using UnityEngine;
using System.Collections;

[System.Serializable]
public class SaveLoadGameScript : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool backMenu = Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7);
		
		if (backMenu) {
			SaveLoadGame.playerData.playerBag = player.GetComponent<PlayerBag>().playerBag;
			SaveLoadGame.playerData.additionalData["PositionX"] = player.transform.position.x;
			SaveLoadGame.playerData.additionalData["PositionY"] = player.transform.position.y;
			SaveLoadGame.Save();
		}
	}
}
