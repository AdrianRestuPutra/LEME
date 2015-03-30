using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CollectedItems : MonoBehaviour {
	public GameObject player;
	public string objectName;
	public GameObject lockedDoor;
	public bool removeAfterTake = false;
	public GameObject hudChat;
	public string chatMessage;
	
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
	
	void GetInputFromUser() {
		bool action = Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (isObjectCollideWithPlayer && action) {
			playerBag.Collecting(objectName);
			if (lockedDoor)
				lockedDoor.GetComponent<HitObject>().enabled = false;
			if (hudChat) {
				hudChat.GetComponent<Text>().text = chatMessage;
				hudChat.GetComponent<Text>().color = new Color(0, 1, 0);
				hudChat.GetComponent<Animator>().Play("Fade HUD Chat", -1, 0);
			}
			GetComponent<CollectedItems>().enabled = false;
			if (GetComponent<HitObject>())
				GetComponent<HitObject>().enabled = true;
			if (removeAfterTake)
				Destroy(gameObject);
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
