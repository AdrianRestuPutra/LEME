using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuChanger : MonoBehaviour {

	public Sprite[] menuSprite;
	private int menuIndex = 0;

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
		bool input = Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		
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
			Application.LoadLevel(2);
			//Application.LoadLevelAsync(1);
			//Application.LoadLevelAdditiveAsync(1);
		}
	}
	
	void ChangeMenu() {
		GameObject.Find("Menu").GetComponent<Image> ().sprite = menuSprite[menuIndex];
	}
}
