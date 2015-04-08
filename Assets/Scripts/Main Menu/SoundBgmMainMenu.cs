using UnityEngine;
using System.Collections;

public class SoundBgmMainMenu : MonoBehaviour {

	public void Awake() {
		DontDestroyOnLoad(this);
		
		if (FindObjectsOfType(GetType()).Length > 1) {
			Destroy(gameObject);
		} else GetComponent<AudioSource>().enabled = true;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
