using UnityEngine;
using System.Collections;

public class BSODScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		bool input = Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button7);
		
		if (input) {
			Application.LoadLevel(1);
		}
	}
}
