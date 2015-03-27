using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float force = 5;
	public GameObject playerGraphic;
	
	private Animator animator;
	private bool isFacingRight= true;

	// Use this for initialization
	void Start () {
		animator = playerGraphic.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		bool rightKey = Input.GetKey(KeyCode.RightArrow);
		bool leftKey = Input.GetKey(KeyCode.LeftArrow);
		bool restart = Input.GetKeyDown(KeyCode.R);
		float axis = Input.GetAxis("Horizontal");
		
		
		if (rightKey || axis >= 1) {
			if (!isFacingRight) Flip();
			rigidbody2D.velocity = new Vector2(force, 0);
			animator.SetBool("Walk", true);
		} else if (leftKey || axis <= -1) {
			if (isFacingRight) Flip();
			rigidbody2D.velocity = new Vector2(-force, 0);
			animator.SetBool("Walk", true);
		} else {
			rigidbody2D.velocity = new Vector2(0, 0);
			animator.SetBool("Walk", false);
		}
		
		if (restart) {
			print("restart");
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	
	void Flip() {
		isFacingRight = !isFacingRight;
		Vector3 vec3 = playerGraphic.transform.localScale;
		vec3.x *= -1;
		playerGraphic.transform.localScale = vec3;
	}
}
