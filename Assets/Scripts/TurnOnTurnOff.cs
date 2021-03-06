﻿using UnityEngine;
using System.Collections;

public class TurnOnTurnOff : MonoBehaviour {
	
	public GameObject light;
	public GameObject[] textGlow;
	
	private bool isObjectCollideWithPlayer = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		InputManager();
	}
	
	void InputManager() {
		bool input = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (input && isObjectCollideWithPlayer) {
			bool isOn = light.GetComponent<Light>().enabled;
			
			light.GetComponent<Light>().enabled ^= true;
			
			if (light.GetComponent<Light>().enabled == false) {
				for(int i=0;i<textGlow.Length;i++)
					textGlow[i].GetComponent<MeshRenderer>().enabled = true;
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
