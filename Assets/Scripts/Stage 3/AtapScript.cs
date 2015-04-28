using UnityEngine;
using System.Collections;

public class AtapScript : MonoBehaviour {
	
	public GameObject player;
	public GameObject tanggaNaik;
	public GameObject tangga;
	
	private bool isObjectCollideWithPlayer = false;
	private PlayerBag playerBag;
	
	void Awake() {
		playerBag = player.GetComponent<PlayerBag>();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerBag.playerAdditionalData.ContainsKey("TanggaAtas")) {
			if (playerBag.playerAdditionalData["TanggaAtas"].Equals("Show"))
				ShowLadder();
		}
		InputManager();
	}
	
	void ShowLadder() {
		tanggaNaik.GetComponent<BoxCollider2D>().enabled = true;
		tangga.GetComponent<SpriteRenderer>().enabled = true;
		
		Destroy(gameObject);
	}
	
	void InputManager() {
		bool action = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (action && isObjectCollideWithPlayer) {
			playerBag.playerAdditionalData["TanggaAtas"] = "Show";
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
