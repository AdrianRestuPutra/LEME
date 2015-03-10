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
		bool escape = Input.GetKeyDown(KeyCode.Escape);
		
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
	}
	
	void ChangeMenu() {
		GameObject.Find("Menu").GetComponent<Image> ().sprite = menuSprite[menuIndex];
	}
}
