﻿using UnityEngine;
using System.Collections;

public class PassedOrFailed : MonoBehaviour {

	public float time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0) {
			Application.LoadLevel(2);
		}
	}
}
