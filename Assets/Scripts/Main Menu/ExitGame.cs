using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitGame : MonoBehaviour {

	public GameObject mainScreen;
	public GameObject[] child;
	
	private int index = 0;
	private string xboxBeforeH = "CENTER";
	private string xboxBeforeV = "CENTER";

	// Use this for initialization
	void Start () {
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		RefreshVisual();
		InputManager();
	}
	
	void InputManager() {
		bool up = Input.GetKeyDown(KeyCode.UpArrow);
		bool down = Input.GetKeyDown(KeyCode.DownArrow);
		bool ok = Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		bool back = Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Joystick1Button1)
			|| Input.GetKeyDown(KeyCode.Escape);
		float vAxisXBOX = Input.GetAxis("Vertical_Joystick");
		
		if (vAxisXBOX >= 0.5 && xboxBeforeV != "UP") {
			up |= true;
			xboxBeforeV = "UP";
		} else if (vAxisXBOX <= -0.5 && xboxBeforeV != "DOWN") {
			down |= true;
			xboxBeforeV = "DOWN";
		} else if (vAxisXBOX == 0) xboxBeforeV = "CENTER";
		
		if (up) {
			index = ((index - 1) + child.Length) % child.Length;
		}
		
		if (down) {
			index = (index + 1) % child.Length;
		}
		
		if (ok) {
			if (index == 0) Application.Quit();
			else {
				this.GetComponent<RectTransform>().offsetMin = new Vector2(-1000, 0);
				this.enabled = false;
				
				mainScreen.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
				mainScreen.GetComponent<MainMenu>().enabled = true;
			}
			index = 0;
		}
		
		if (back) {
			this.GetComponent<RectTransform>().offsetMin = new Vector2(-1000, 0);
			this.enabled = false;
			
			mainScreen.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
			mainScreen.GetComponent<MainMenu>().enabled = true;
			index = 0;
		}
	}
	
	void RefreshVisual() {
		for(int i=0;i<child.Length;i++) {
			child[i].GetComponent<Text>().color = new Color(1,1,1);
		}
		
		child[index].GetComponent<Text>().color = new Color(0.184f,0.67f,0.17f);
	}
}
