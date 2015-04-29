using UnityEngine;
using System.Collections;

public class FireOff : MonoBehaviour {

	public GameObject player;
	public GameObject fire;
	public GameObject wall;
	
	private PlayerBag playerBag;
	private bool isObjectCollideWithPlayer = false;
	
	void Awake() {
		playerBag = player.GetComponent<PlayerBag>();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate() {
		if (playerBag.IsCollected("Ember")) {
			if (playerBag.playerBag["Ember"].Equals("Isi"))
				gameObject.GetComponent<HitObject>().enabled = false;
		}
		
		if (playerBag.playerAdditionalData.ContainsKey("Fire")) {
			if (playerBag.playerAdditionalData["Fire"].Equals("TurnedOff")) {
				Destroy(fire);
				Destroy(wall);
				Destroy(gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		bool input = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (input && isObjectCollideWithPlayer) {
			if (playerBag.IsCollected("Ember")) {
				if (playerBag.playerBag["Ember"].Equals("Isi")) {
					playerBag.playerBag["Ember"] = "Kosong";
					playerBag.playerAdditionalData["Fire"] = "TurnedOff";
					fire.GetComponent<ParticleEmitter>().emit = false;
					fire.GetComponent<AudioSource>().enabled = false;
					Destroy(wall);
					Destroy(gameObject);
				}
			}
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
