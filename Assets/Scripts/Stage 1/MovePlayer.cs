using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float force = 5;
	public float boostAdd = 3;
	public GameObject playerGraphic;
	public GameObject mainCamera;
	
	private Animator animator;
	public bool isFacingRight = true;
	private AudioSource[] audioSources;
	private float initialForce;
	private Vector2 rightForce, leftForce;
	private Vector2 boostRightForce, boostLeftForce;
	private Vector2 moveForce, stopForce;
	private bool isBoost = false;
	
	/*
		IDLE = 0;
		RIGHT = 1;
		LEFT = -1;
	*/
	
	public int state = 0;
	public int stateBefore = 0;

	// Use this for initialization
	void Start () {
		animator = playerGraphic.GetComponent<Animator>();
		audioSources = GetComponents<AudioSource>();
		state = stateBefore = 0;
		initialForce = force;
		
		rightForce = new Vector2(force, 0);
		leftForce = new Vector2(-force, 0);
		
		boostRightForce = new Vector2(force + boostAdd, 0);
		boostLeftForce = new Vector2(-(force + boostAdd), 0);
		
		stopForce = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		bool rightKey = Input.GetKey(KeyCode.RightArrow);
		bool leftKey = Input.GetKey(KeyCode.LeftArrow);
		bool restart = Input.GetKeyDown(KeyCode.R);
		bool backMenu = Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7);
		float axis = Input.GetAxis("Horizontal_Joystick");
		float boost = Input.GetAxis("Boost_Joystick");
		bool boostKeyboard = Input.GetKey(KeyCode.LeftShift);
		
		if (boost >= 0.5f || boostKeyboard) {
			if (GetComponent<Hunger>())
				GetComponent<Hunger>().BoostMove();
			isBoost = true;
		} else {
			if (GetComponent<Hunger>())
				GetComponent<Hunger>().StandartMove();
			isBoost = false;
		}
			
		
		
		if (rightKey || axis >= 0.5) {
			state = 1;
			/*if (!isFacingRight) Flip();
			rigidbody2D.velocity = new Vector2(force, 0);
			animator.SetBool("Walk", true);
			audioSources[0].enabled = true;*/
		} else if (leftKey || axis <= -0.5) {
			state = -1;
			/*if (isFacingRight) Flip();
			rigidbody2D.velocity = new Vector2(-force, 0);
			animator.SetBool("Walk", true);
			audioSources[0].enabled = true;*/
		} else {
			state = 0;
			/*rigidbody2D.velocity = new Vector2(0, 0);
			animator.SetBool("Walk", false);
			audioSources[0].enabled = false;*/
		}
		
		if (restart) {
			print("restart");
			Application.LoadLevel(Application.loadedLevel);
		}
		
		if (backMenu) {
			Application.LoadLevel(1);
		}
		
		if (state == 1) {
			//rigidbody2D.velocity = new Vector2(force, 0);
			if (isBoost) GetComponent<Rigidbody2D>().velocity = boostRightForce;
			else GetComponent<Rigidbody2D>().velocity = rightForce;
		} else if (state == -1) {
			//rigidbody2D.velocity = new Vector2(-force, 0);
			if (isBoost) GetComponent<Rigidbody2D>().velocity = boostLeftForce;
			else GetComponent<Rigidbody2D>().velocity = leftForce;
		} else {
			GetComponent<Rigidbody2D>().velocity = stopForce;
			//rigidbody2D.velocity = new Vector2(0, 0);
		}
	}
	
	void FixedUpdate() {
		if (state == 1 && stateBefore != state) {
			stateBefore = 1;
			if (!isFacingRight) Flip();
			//rigidbody2D.velocity = new Vector2(force, 0);
			animator.SetBool("Walk", true);
			audioSources[0].enabled = true;
		} else if (state == -1 && state != stateBefore) {
			stateBefore = -1;
			if (isFacingRight) Flip();
			//rigidbody2D.velocity = new Vector2(-force, 0);
			animator.SetBool("Walk", true);
			audioSources[0].enabled = true;
		} else if (state == 0 && state != stateBefore) {
			stateBefore = 0;
			//rigidbody2D.velocity = new Vector2(0, 0);
			animator.SetBool("Walk", false);
			audioSources[0].enabled = false;
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
    
    public void Done() {
        GetComponent<Rigidbody2D>().velocity = stopForce;
    }
}