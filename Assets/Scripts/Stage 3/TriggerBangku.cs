using UnityEngine;
using System.Collections;

public class TriggerBangku : MonoBehaviour {

	public GameObject player;
	public GameObject bangku;
	public GameObject triggerNaikBangku;
	
	private PlayerBag playerBag;
	private bool isObjectCollideWithPlayer = false;

	void Awake () {
		playerBag = player.GetComponent<PlayerBag>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerBag.playerAdditionalData.ContainsKey("NaruhBangku")) {
			if (playerBag.playerAdditionalData["NaruhBangku"].Equals("SudahDitaruh"))
				NaruhBangku();
		}
		
		if (playerBag.IsCollected("Bangku")) {
			GetComponent<HitObject>().enabled = false;
		}
		
		InputManager();
	}
	
	void InputManager() {
		bool action = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (action && isObjectCollideWithPlayer) {
			if (playerBag.IsCollected("Bangku")) {
				playerBag.playerAdditionalData["NaruhBangku"] = "SudahDitaruh";
			} else playerBag.playerAdditionalData["BisaNgambilBangku"] = "Bisa";
		}
	}
	
	void NaruhBangku() {
		bangku.GetComponent<SpriteRenderer>().enabled = true;
		BoxCollider2D[] col = triggerNaikBangku.GetComponents<BoxCollider2D>();
		col[0].enabled = true;
		col[1].enabled = true;
		triggerNaikBangku.GetComponent<NaikBangku>().enabled = true;
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
