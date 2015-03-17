using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float force = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool rightKey = Input.GetKey(KeyCode.RightArrow);
		bool leftKey = Input.GetKey(KeyCode.LeftArrow);
		
		float axis = Input.GetAxis("Horizontal");
		
		
		if (rightKey || axis >= 1) {
			rigidbody2D.velocity = new Vector2(force, 0);
		} else if (leftKey || axis <= -1) {
			rigidbody2D.velocity = new Vector2(-force, 0);
		} else {
			rigidbody2D.velocity = new Vector2(0, 0);
		}
	}
}
