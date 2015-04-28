using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float force = 5;
	public GameObject playerGraphic;
	public GameObject mainCamera;
	
	private Animator animator;
	public bool isFacingRight = true;
	private AudioSource[] audioSources;

	// Use this for initialization
	void Start () {
		animator = playerGraphic.GetComponent<Animator>();
		audioSources = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		bool rightKey = Input.GetKey(KeyCode.RightArrow);
		bool leftKey = Input.GetKey(KeyCode.LeftArrow);
		bool restart = Input.GetKeyDown(KeyCode.R);
		bool backMenu = Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7);
		float axis = Input.GetAxis("Horizontal_Joystick");
		
		
		if (rightKey || axis >= 0.5) {
			if (!isFacingRight) Flip();
			rigidbody2D.velocity = new Vector2(force, 0);
			animator.SetBool("Walk", true);
			audioSources[0].enabled = true;
		} else if (leftKey || axis <= -0.5) {
			if (isFacingRight) Flip();
			rigidbody2D.velocity = new Vector2(-force, 0);
			animator.SetBool("Walk", true);
			audioSources[0].enabled = true;
		} else {
			rigidbody2D.velocity = new Vector2(0, 0);
			animator.SetBool("Walk", false);
			audioSources[0].enabled = false;
		}
		
		if (restart) {
			print("restart");
			Application.LoadLevel(Application.loadedLevel);
		}
		
		if (backMenu) {
			Application.LoadLevel(1);
		}
	}
	
	void Flip() {
		isFacingRight = !isFacingRight;
		Vector3 vec3 = playerGraphic.transform.localScale;
		vec3.x *= -1;
		playerGraphic.transform.localScale = vec3;
	}
	
	public void PlayOpenDoor() {
		mainCamera.GetComponents<AudioSource>()[1].Play();
	}
}
