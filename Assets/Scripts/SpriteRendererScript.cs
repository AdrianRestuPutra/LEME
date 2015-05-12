using UnityEngine;
using System.Collections;

public class SpriteRendererScript : MonoBehaviour {

	public GameObject objectRenderer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnBecameInvisible () {
		if (objectRenderer)
			objectRenderer.GetComponent<SpriteRenderer>().enabled = false;
	}
	
	void OnBecameVisible () {
		if (objectRenderer)
			objectRenderer.GetComponent<SpriteRenderer>().enabled = true;
	}
}
