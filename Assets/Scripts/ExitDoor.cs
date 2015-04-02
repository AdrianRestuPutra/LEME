using UnityEngine;
using Parse;
using System.Collections;

public class ExitDoor : MonoBehaviour {
	public GameObject player;
	public bool isBlindMode;
	public string className;

	private bool isObjectCollideWithPlayer = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetInputFromUser();
	}
	
	void GetInputFromUser() {
		bool input = Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (input && isObjectCollideWithPlayer) {
			if (player.GetComponent<PlayerBag>().IsCollected("exit-key")) {
				print("KELUAR");
				if (isBlindMode) {
					ParseObject obj = new ParseObject(className);
					obj["userId"] = "1234567890";
					obj["userName"] = "madya121";
					obj["timeMs"] = 1000;
					obj.SaveAsync();
				}
				Application.LoadLevel(1);
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isObjectCollideWithPlayer = true;
			print ("Object start to collide");
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isObjectCollideWithPlayer = false;
			print ("Object stop to collide");
		}
	}
}
