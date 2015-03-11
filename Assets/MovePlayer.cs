using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float force = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool right = Input.GetKey(KeyCode.RightArrow);
		bool left = Input.GetKey(KeyCode.LeftArrow);
		
		if (right) {
			rigidbody2D.velocity = new Vector2(force, 0);
		} else if (left) {
			rigidbody2D.velocity = new Vector2(-force, 0);
		} else {
			rigidbody2D.velocity = new Vector2(0, 0);
		}
	}
}
