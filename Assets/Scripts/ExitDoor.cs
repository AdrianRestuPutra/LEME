using UnityEngine;
using System.Collections;

public class ExitDoor : MonoBehaviour {
	public GameObject player;

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
