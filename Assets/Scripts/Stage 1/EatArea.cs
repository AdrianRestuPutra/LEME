using UnityEngine;
using System.Collections;

public class EatArea : MonoBehaviour {
	public GameObject player;
	public GameObject stock;

	private bool isObjectCollideWithPlayer = false;
	private FoodStock foodStock;
	private Hunger hunger;
	
	// Use this for initialization
	void Start () {
		foodStock = stock.GetComponent<FoodStock>();
		hunger    = player.GetComponent<Hunger>();
	}
	
	// Update is called once per frame
	void Update () {
		GetInputFromUser();
	}
	
	void GetInputFromUser() {
		bool action = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (isObjectCollideWithPlayer && action) {
			if (foodStock.PlayerEat() == true) {
				// USER MAKAN
				hunger.PlayerEat();
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
