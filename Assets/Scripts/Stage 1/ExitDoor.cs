﻿using UnityEngine;
using Parse;
using System.Collections;

using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class ExitDoor : MonoBehaviour {
	public GameObject player;
	public bool isBlindMode;
	public string className;
	public GameObject passed;

	private bool isObjectCollideWithPlayer = false;
	
	// Use this for initialization
	void Start () {
		//player.GetComponent<PlayerBag>().Collecting("exit-key");
	}
	
	// Update is called once per frame
	void Update () {
		GetInputFromUser();
	}
	
	void GetInputFromUser() {
		bool input = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (input && isObjectCollideWithPlayer) {
			if (player.GetComponent<PlayerBag>().IsCollected("exit-key")) {
				print("KELUAR");
				if (isBlindMode) {
					/*ParseObject obj = new ParseObject(className);
					obj["userId"] = "1234567890";
					obj["userName"] = "madya121";
					obj["timeMs"] = 1000;
					obj.SaveAsync();*/
				} else {
					if (SaveLoadGame.SavedExist())
						File.Delete(Application.persistentDataPath + "/LeMe.zd");
				}
				//Application.LoadLevel(2);
				
				ParseObject obj = new ParseObject("Statistik");
				obj.ObjectId = "tJESUgUX5L";
				obj.Increment("SuccessOut");
				obj.SaveAsync();
				
				passed.GetComponent<SpriteRenderer>().enabled = true;
				passed.GetComponent<Animator>().SetTrigger("Passed");
				passed.GetComponent<PassedOrFailed>().enabled = true;
				
				GameObject.Find("Player Graphic").GetComponent<Animator>().SetBool("Walk", false);
				player.GetComponent<AudioSource>().enabled = false;
				
				Object[] objects = GameObject.FindObjectsOfType<GameObject>();
				foreach (Object _object in objects) {
					if (_object.Equals(passed) == false) {
						MonoBehaviour[] monoBehaviors = ((GameObject)_object).GetComponents<MonoBehaviour>();
						foreach(MonoBehaviour monoBehavior in monoBehaviors) {
							monoBehavior.enabled = false;
						}
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
