using UnityEngine;
using System.Collections;

public class StairScript : MonoBehaviour {

	public GameObject wayPoint;
	
	private bool isObjectCollideWithPlayer = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isObjectCollideWithPlayer) {
			wayPoint.GetComponent<SpriteRenderer>().enabled = true;
		} else wayPoint.GetComponent<SpriteRenderer>().enabled = false;
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
