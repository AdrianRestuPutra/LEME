using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public float time = 6;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0) {
			Application.LoadLevel(1);
		}
	}
}
