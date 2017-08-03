using UnityEngine;
using System.Collections;

public class LockedDoorWithKey : MonoBehaviour {
	
	public GameObject player;
	public GameObject moveTo;
	public string keyName;
	
	private PlayerBag playerBag;
	private bool isObjectCollideWithPlayer = false;

	// Use this for initialization
	void Start () {
		playerBag = player.GetComponent<PlayerBag>();
	}
	
	// Update is called once per frame
	void Update () {
		GetInputFromUser();
	}
	
	void FixedUpdate() {
		if (playerBag.IsCollected(keyName)) {
			if (GetComponent<HitObject>())
				GetComponent<HitObject>().enabled = false;
		}
	}
	
	void GetInputFromUser() {
		bool action = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (action && isObjectCollideWithPlayer) {
			if (playerBag.IsCollected(keyName)) {
				// Move Player to next object
				player.transform.position = moveTo.transform.position;
				player.GetComponent<MovePlayer>().PlayOpenDoor();
			} else {
				print("You don't have a key");
				GetComponent<AudioSource>().Play();
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
