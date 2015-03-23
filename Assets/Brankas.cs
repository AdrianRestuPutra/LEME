using UnityEngine;
using System.Collections;

public class Brankas : MonoBehaviour {
	public GameObject player;
	public GameObject brankasInput;
	
	private bool isObjectCollideWithPlayer = false;
	private GameObject objectShownInCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetInputFromUser();
	}
	
	void GetInputFromUser() {
		bool action = Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (action && isObjectCollideWithPlayer) {
			brankasInput.GetComponent<BrankasInput>().brankas = gameObject;
			brankasInput.GetComponent<BrankasInput>().rightAnswer = 1208;
			brankasInput.GetComponent<BrankasInput>().objectInside = "exit-key";
			Instantiate(brankasInput);
			gameObject.GetComponent<Brankas>().enabled = false;
			player.GetComponent<MovePlayer>().enabled = false;
			print("Action Accepted");
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
