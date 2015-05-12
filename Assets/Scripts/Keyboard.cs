using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Keyboard : MonoBehaviour {

	public GameObject[] listLetter;
	
	private string xboxBeforeH = "CENTER";
	private string xboxBeforeV = "CENTER";
	private int index = 0;
	private float second = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		second += Time.deltaTime;
		if (second >= 0.5) {
			second = 0;
			xboxBeforeH = "CENTER";
			xboxBeforeV = "CENTER";
		}
		InputManager();
		Visualize();
	}
	
	void InputManager() {
		bool left = Input.GetKeyDown(KeyCode.LeftArrow);
		bool right = Input.GetKeyDown(KeyCode.RightArrow);
		
		bool up = Input.GetKeyDown(KeyCode.UpArrow);
		bool down = Input.GetKeyDown(KeyCode.DownArrow);
		
		bool input = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
		bool cancel = Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Joystick1Button1);
		
		float hAxisXBOX = Input.GetAxis("Horizontal_Joystick");
		float vAxisXBOX = Input.GetAxis("Vertical_Joystick");
		
		if (hAxisXBOX >= 0.5 && xboxBeforeH != "RIGHT") {
			right |= true;
			xboxBeforeH = "RIGHT";
			second = 0;
		} else if (hAxisXBOX <= -0.5 && xboxBeforeH != "LEFT") {
			left |= true;
			xboxBeforeH = "LEFT";
			second = 0;
		} else if (hAxisXBOX == 0) xboxBeforeH = "CENTER";
		
		if (vAxisXBOX >= 0.5 && xboxBeforeV != "UP") {
			up |= true;
			xboxBeforeV = "UP";
			second = 0;
		} else if (vAxisXBOX <= -0.5 && xboxBeforeV != "DOWN") {
			down |= true;
			xboxBeforeV = "DOWN";
			second = 0;
		} else if (vAxisXBOX == 0) xboxBeforeV = "CENTER";
		
		if (left) index = ((index - 1) + 39) % 39;
		else if (right) index = (index + 1) % 39;
		
		if (up) {
			if (index <= 2 && index >= 0) index = 30 + index;
			else if (index >= 3 && index <= 4) index = 37;
			else if (index >= 5 && index <= 6) index = 38;
			else if (index == 7) index = 35;
			else if (index == 8 || index == 9) index = 36;
			else if (index == 38) index = 33;
			else if (index == 37) index = 23;
			else if (index == 33 || index == 34 || index == 35 || index == 36) index = index - 8;
			else index -= 10;
		} else if (down) {
			if (index == 30 || index == 31 || index == 32 || index == 23 || index == 24) index= 37;
			else if (index == 33 || index == 34 || index == 35 || index == 36) index = 38;
			else if (index == 25 || index == 26 || index == 27) index += 8;
			else if (index == 28 || index == 29) index = 36;
			else if (index == 37) index = 3;
			else if (index == 38) index = 5;
			else index += 10;
		}
	}
	
	void Visualize() {
		for(int i=0;i<listLetter.Length;i++) {
			listLetter[i].GetComponent<Image>().enabled = false;
		}
		
		listLetter[index].GetComponent<Image>().enabled = true;
	}
	
	public string GetString() {
		return listLetter[index].name;
	}
}
