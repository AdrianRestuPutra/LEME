using UnityEngine;
using System.Collections;

public class ObjectScript : MonoBehaviour {

	private bool isObjectCollideWithPlayer = false;
	private bool isObjectShownInCamera = false;
	private GameObject objectShownInCamera;
	
	public Sprite objectImage;
	public bool destroyAfterShow = false;
	public float scale = 1;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetInputFromUser();
	}
	
	void GetInputFromUser() {
		bool action = Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (action && isObjectCollideWithPlayer) {
			if (isObjectShownInCamera == false) {
				RemoveUserInput();
				ShowObjectToCamera();
				isObjectShownInCamera = true;
			} else {
				AddUserInput();
				RemoveObjectFromCamera();
				isObjectShownInCamera = false;
				if (destroyAfterShow == true)
					Destroy(gameObject);
			}
			print("Action Accepted");
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isObjectCollideWithPlayer = true;
			print ("Object start to collide");
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isObjectCollideWithPlayer = false;
			print ("Object stop to collide");
		}
	}
	
	void ShowObjectToCamera() {
		GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		GameObject objectShown = new GameObject();
		objectShown.name = "Object Shown";
		objectShown.AddComponent("SpriteRenderer");
		objectShown.GetComponent<SpriteRenderer>().sprite = objectImage;
		
		Destroy((GameObject)Instantiate(objectShown));
		
		objectShown.transform.parent = mainCamera.transform;
		objectShown.transform.localPosition = new Vector3(0, 0, 1);
		objectShown.transform.localScale = new Vector3(scale, scale, 0);
		objectShownInCamera = objectShown;
	}
	
	void RemoveObjectFromCamera() {
		Destroy(objectShownInCamera);
	}
	
	void RemoveUserInput() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Rigidbody2D rigidbody2D = player.GetComponent<Rigidbody2D> ();
		MovePlayer movePlayer = player.GetComponent<MovePlayer> ();
		
		rigidbody2D.velocity = new Vector2(0, 0);
		movePlayer.enabled = false;
	}
	
	void AddUserInput() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		MovePlayer movePlayer = player.GetComponent<MovePlayer> ();
		movePlayer.enabled = true;
	}
}
