using UnityEngine;
using System.Collections;

public class DoorSideScript : MonoBehaviour {

	public GameObject player;
	public string key;
	public GameObject door;
	
	private bool isObjectCollideWithPlayer = false;

	// Use this for initialization
	void Start () {
		if (player.GetComponent<PlayerBag>().IsCollected(key))
			OpenDoor();
	}
	
	void OpenDoor() {
		door.GetComponent<SpriteRenderer>().enabled = true;
		door.GetComponent<BoxCollider2D>().enabled = false;
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		bool input = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (input && isObjectCollideWithPlayer) {
			if (player.GetComponent<PlayerBag>().IsCollected(key)) {
				OpenDoor();
			}
		}
	}
	
	void FixedUpdate() {
		if (player.GetComponent<PlayerBag>().IsCollected(key)) {
			GetComponent<HitObject>().enabled = false;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isObjectCollideWithPlayer = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isObjectCollideWithPlayer = false;
		}
	}
}
