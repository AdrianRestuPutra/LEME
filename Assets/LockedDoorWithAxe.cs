﻿using UnityEngine;
using System.Collections;

public class LockedDoorWithAxe : MonoBehaviour {
	public GameObject player;
	public GameObject moveTo;
	public GameObject woodLock;
	
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
		
		if (action && isObjectCollideWithPlayer) {
			if (playerBag.IsCollected("axe")) {
				// Move Player to next object
				if (woodLock) {
					Destroy(woodLock);
				} else {
					player.transform.position = moveTo.transform.position;
				}
			} else print("You don't have a axe");
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
