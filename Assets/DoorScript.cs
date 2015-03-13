using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {
	private bool isObjectCollideWithPlayer = false;
	public GameObject door;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetInputFromUser ();
	}

	void GetInputFromUser() {
		bool action = Input.GetKeyDown(KeyCode.X);
		
		if (action && isObjectCollideWithPlayer) {
			MovePlayer();
			print("pindah");
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

	void MovePlayer() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Vector3 doorPosition = door.transform.position;
		player.transform.position = doorPosition;
	}

}
