using UnityEngine;
using System.Collections;

public class RuangTamuScript : MonoBehaviour {

	public GameObject player;
	public GameObject sprite;
	public GameObject wall;
	public GameObject trigger;
	public GameObject light;
	public GameObject flareLight;
	public GameObject smoke;
	public Material materialChange;
	
	private bool isObjectCollideWithPlayer = false;
	private PlayerBag playerBag;

	void Awake () {
		playerBag = player.GetComponent<PlayerBag>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerBag.playerAdditionalData.ContainsKey("MeetingRoom")) {
			if (playerBag.playerAdditionalData["MeetingRoom"].Equals("Nyala"))
				RemoveObject();
		}
		InputManager();
	}
	
	void InputManager() {
		bool action = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (action && isObjectCollideWithPlayer && playerBag.IsCollected("pematik-api")) {
			playerBag.playerAdditionalData["MeetingRoom"] = "Nyala";
		}
	}
	
	void RemoveObject() {
		flareLight.GetComponent<Light>().enabled = true;
		smoke.GetComponent<ParticleEmitter>().emit = true;
	
		Destroy(light);
		Destroy(wall);
		Destroy(trigger);
		
		sprite.GetComponent<SpriteRenderer>().material = materialChange;
		Destroy(gameObject);
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
