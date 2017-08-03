using UnityEngine;
using System.Collections;

public class PassedOrFailed : MonoBehaviour {
	
	public bool isBlindMode = false;
	public float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0) {
			if (isBlindMode)
				Application.LoadLevel("Score View");
			else Application.LoadLevel("LevelSelection");
		}
	}
}
