using UnityEngine;
using System.Collections;

public class LiftDoorScript : MonoBehaviour {

	public GameObject player;
	public GameObject liftScript;

	private bool isObjectCollideWithPlayer = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool input = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (input && isObjectCollideWithPlayer) {
			player.GetComponent<MovePlayer>().enabled = false;
			player.GetComponent<MovePlayer>().playerGraphic.GetComponent<Animator>().SetBool("Walk", false);
			liftScript.GetComponent<LiftScript>().enabled = true;
			this.enabled = false;
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
