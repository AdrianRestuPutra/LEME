﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BangkuKamar1 : MonoBehaviour {

	public GameObject player;
	public GameObject hudChat;
	public string chatMessage;

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
		if (playerBag.IsCollected("Bangku"))
			Destroy(gameObject);
		InputManager();
	}
	
	void InputManager() {
		bool action = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (action && isObjectCollideWithPlayer) {
			if (playerBag.playerAdditionalData.Contains("BisaNgambilBangku")) {
				if (playerBag.playerAdditionalData["BisaNgambilBangku"].Equals("Bisa")) {
					playerBag.Collecting("Bangku");
					if (hudChat) {
						hudChat.GetComponent<Text>().text = chatMessage;
						hudChat.GetComponent<Text>().color = new Color(0, 1, 0);
						hudChat.GetComponent<Animator>().Play("Fade HUD Chat", -1, 0);
					}
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
