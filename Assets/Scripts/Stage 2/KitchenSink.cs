using UnityEngine;
using System.Collections;

public class KitchenSink : MonoBehaviour {

	public GameObject player;
	public GameObject water;

	private PlayerBag playerBag;
	private bool isFix = false;
	private bool isObjectCollideWithPlayer = false;
	
	// Use this for initialization
	void Start () {
		playerBag = player.GetComponent<PlayerBag>();
	}
	
	// Update is called once per frame
	void Update () {
		GetInputFromUser();
		Visualize();
		if (playerBag.IsCollected("Wrench"))
			gameObject.GetComponent<HitObject>().enabled = false;
			
		if (playerBag.playerAdditionalData.ContainsKey("IsSinkFix")) {
			if (playerBag.playerAdditionalData["IsSinkFix"].Equals("True"))
				isFix = true;
		}
	}
	
	void GetInputFromUser() {
		bool input = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (input && isObjectCollideWithPlayer) {
			if (!isFix) {
				if (playerBag.IsCollected("Wrench")) {
					isFix = true;
					playerBag.playerAdditionalData["IsSinkFix"] = "True";
				}
			} else {
				if (playerBag.IsCollected("Ember"))
					playerBag.playerBag["Ember"] = "Isi";
				print(playerBag.playerBag["Ember"]);
			}
		}
	}
	
	void Visualize() {
		if (isFix)
			water.GetComponent<ParticleEmitter>().emit = true;
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
