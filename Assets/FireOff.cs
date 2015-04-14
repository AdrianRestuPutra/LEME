using UnityEngine;
using System.Collections;

public class FireOff : MonoBehaviour {

	public GameObject player;
	public GameObject fire;
	public GameObject wall;
	
	private PlayerBag playerBag;
	private bool isObjectCollideWithPlayer = false;

	// Use this for initialization
	void Start () {
		playerBag = player.GetComponent<PlayerBag>();
	}
	
	// Update is called once per frame
	void Update () {
		bool input = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (input && isObjectCollideWithPlayer) {
			if (playerBag.IsCollected("Ember")) {
				if (playerBag.playerBag["Ember"].Equals("Isi")) {
					playerBag.playerBag["Ember"] = "Kosong";
					Destroy(wall);
					fire.GetComponent<ParticleEmitter>().emit = false;
					Destroy(gameObject);
				}
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
}
