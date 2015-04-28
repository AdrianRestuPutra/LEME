using UnityEngine;
using System.Collections;

public class DigitCounterClick : MonoBehaviour {

	public GameObject mainPuzzle;
	public int[] counterPerDigit;
	
	private bool isObjectCollideWithPlayer = false;
	private int digitCount;

	// Use this for initialization
	void Start () {
		digitCount = mainPuzzle.GetComponent<DigitCounterPuzzle>().digitCount;
	}
	
	// Update is called once per frame
	void Update () {
		InputManager();
		CheckIfPuzzleSolved();
	}
	
	void CheckIfPuzzleSolved() {
		if (mainPuzzle.GetComponent<DigitCounterPuzzle>() == null)
			Destroy(GetComponent<DigitCounterClick>());
	}
	
	void InputManager() {
		bool input = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		if (input && isObjectCollideWithPlayer) {
			for (int i=0;i<digitCount;i++) {
				mainPuzzle.GetComponent<DigitCounterPuzzle>().AddDigit(i, counterPerDigit[i]);
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isObjectCollideWithPlayer = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			isObjectCollideWithPlayer = false;
		}
	}
}
