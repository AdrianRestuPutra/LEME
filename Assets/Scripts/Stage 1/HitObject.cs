using UnityEngine;
using System.Collections;

public class HitObject : MonoBehaviour {
	public GameObject player;
	public int[] dialogueID;
	private bool input;
	private bool isObjectCollideWithPlayer = false;
	private bool isShown = false;

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
		input = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);

		if (input && isObjectCollideWithPlayer) {
			if (isShown == false) {
				isShown = true;
				int id = Random.Range(0, dialogueID.Length);
				Dialoguer.StartDialogue(dialogueID[id],dialoguerCallBack);
				RemoveUserInput();
			} else {
				isShown = false;
				Dialoguer.EndDialogue();
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

	private void RemoveUserInput() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D> ();
		MovePlayer movePlayer = player.GetComponent<MovePlayer> ();
		
		rigidbody2D.velocity = new Vector2(0, 0);
		movePlayer.enabled = false;
		player.GetComponent<MovePlayer>().playerGraphic.GetComponent<Animator>().SetBool("Walk", false);
		player.GetComponents<AudioSource>()[0].enabled = false;
	}

	private void dialoguerCallBack(){
		this.enabled = true;
	}
	
	public bool GetIsShown() {
		return isShown;
	}
}
