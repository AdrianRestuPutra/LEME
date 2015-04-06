using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuChanger : MonoBehaviour {

	public Sprite[] menuSprite;
	public int[] puzzleLevel;
	public int[] blindLevel;
	public GameObject soundBGM;
	public GameObject lampMainMenu;
	
	private int menuIndex = 0;
	private string xboxBeforeH = "CENTER";

	// Use this for initialization
	void Start () {
		ChangeMenu();
	}
	
	// Update is called once per frame
	void Update () {
		InputManager();
	}
	
	void InputManager() {
		bool left = Input.GetKeyDown(KeyCode.LeftArrow);
		bool right = Input.GetKeyDown(KeyCode.RightArrow);
		bool escape = Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button1);
		
		bool input = Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		bool inputMaze = Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Joystick1Button3);
		
		bool setting = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Joystick1Button2);
		
		float hAxisXBOX = Input.GetAxis("Horizontal_Joystick");
		
		if (hAxisXBOX >= 0.5 && xboxBeforeH != "RIGHT") {
			right |= true;
			xboxBeforeH = "RIGHT";
		} else if (hAxisXBOX <= -0.5 && xboxBeforeH != "LEFT") {
			left |= true;
			xboxBeforeH = "LEFT";
		} else if (hAxisXBOX == 0) xboxBeforeH = "CENTER";
		
		if (left) {
			menuIndex = ((menuIndex - 1) + menuSprite.Length) % menuSprite.Length;
			ChangeMenu();
		} else if (right) {
			menuIndex = (menuIndex + 1) % menuSprite.Length;
			ChangeMenu();
		}
		
		if (escape) {
			Application.Quit();
		}
		
		if (input) {
			if (puzzleLevel[menuIndex] != -1) {
				Destroy(soundBGM);
				Destroy(lampMainMenu);
				Application.LoadLevel(puzzleLevel[menuIndex]);
			}
		}
		
		if (inputMaze) {
			if (blindLevel[menuIndex] != -1) {
				Destroy(soundBGM);
				Destroy(lampMainMenu);
				Application.LoadLevel(blindLevel[menuIndex]);
			}
		}
		
		if (setting) {
			Application.LoadLevel(5);
		}
	}
	
	void ChangeMenu() {
		print ("asd");
		GameObject.Find("Menu").GetComponent<Image> ().sprite = menuSprite[menuIndex];
	}
}
