using UnityEngine;
using System.Collections;

public class HitObject : MonoBehaviour {
	public GameObject player;
	private bool input;
	private bool isObjectCollideWithPlayer = false;

	void Awake(){
		Dialoguer.Initialize ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GetInputFromUser();
	}

	void GetInputFromUser() {
		input = Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button0);

		if (input && isObjectCollideWithPlayer) {
			Dialoguer.StartDialogue(0,dialoguerCallBack);
			RemoveUserInput();
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

	private void RemoveUserInput() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D> ();
		MovePlayer movePlayer = player.GetComponent<MovePlayer> ();
		
		rigidbody2D.velocity = new Vector2(0, 0);
		movePlayer.enabled = false;
	}

	private void dialoguerCallBack(){
		this.enabled = true;
	}
}
