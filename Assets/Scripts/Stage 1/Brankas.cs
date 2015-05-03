using UnityEngine;
using System.Collections;

public class Brankas : MonoBehaviour {
	public GameObject player;
	public GameObject brankasInput;
	public GameObject hudChat;
	public string chatMessage;
	public int rightAnswer;
	public string objectName;
	public float scale = 1;
	
	private bool isObjectCollideWithPlayer = false;
	private GameObject objectShownInCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetInputFromUser();
	}
	
	void FixedUpdate() {
		if (player.GetComponent<PlayerBag>().IsCollected(objectName))
			Destroy(gameObject);
	}
	
	void GetInputFromUser() {
		bool action = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (action && isObjectCollideWithPlayer) {
			brankasInput.GetComponent<BrankasInput>().brankas = gameObject;
			brankasInput.GetComponent<BrankasInput>().rightAnswer = rightAnswer;
			brankasInput.GetComponent<BrankasInput>().objectInside = objectName;
			brankasInput.GetComponent<BrankasInput>().hudChat = hudChat;
			brankasInput.GetComponent<BrankasInput>().chatMessage = chatMessage;
			brankasInput.transform.localScale = new Vector3(scale, scale, 1f);
			Instantiate(brankasInput);
			gameObject.GetComponent<Brankas>().enabled = false;
			player.GetComponent<MovePlayer>().enabled = false;
			player.GetComponent<MovePlayer>().playerGraphic.GetComponent<Animator>().SetBool("Walk", false);
			player.GetComponents<AudioSource>()[0].enabled = false;
			print("Action Accepted");
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
