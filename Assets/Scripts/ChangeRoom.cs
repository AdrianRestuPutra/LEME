using UnityEngine;
using System.Collections;

public class ChangeRoom : MonoBehaviour {

	public GameObject moveTo;
	public GameObject player;
	public bool makeSound = true;
	
	private bool isObjectCollideWithPlayer = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		UserInput();
	}
	
	void UserInput() {
		bool input = Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (input && isObjectCollideWithPlayer) {
			player.transform.position = moveTo.transform.position;
			if (makeSound)
				player.GetComponent<MovePlayer>().PlayOpenDoor();
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
