using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject[] listMenu;
	public GameObject mainSetting;
	public GameObject exitSetting;
	
	private int index = 1;
	private string xboxBeforeH = "CENTER";
	private string xboxBeforeV = "CENTER";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		InputManager();
		RefreshVisual();
	}
	
	void InputManager() {
		bool up = Input.GetKeyDown(KeyCode.UpArrow);
		bool down = Input.GetKeyDown(KeyCode.DownArrow);
		bool ok = Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0) 
			|| Input.GetKeyDown(KeyCode.A);
		bool back = Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Joystick1Button1)
			|| Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.B);
		float vAxisXBOX = Input.GetAxis("Vertical_Joystick");
		
		if (vAxisXBOX >= 0.5 && xboxBeforeV != "UP") {
			up |= true;
			xboxBeforeV = "UP";
		} else if (vAxisXBOX <= -0.5 && xboxBeforeV != "DOWN") {
			down |= true;
			xboxBeforeV = "DOWN";
		} else if (vAxisXBOX == 0) xboxBeforeV = "CENTER";
		
		if (up) {
			index = ((index - 1) + listMenu.Length) % listMenu.Length;
		}
		
		if (down) {
			index = (index + 1) % listMenu.Length;
		}
		
		if (ok) {
			MainScreenChoose();
		}
		
		if (back) {
			this.GetComponent<RectTransform>().offsetMin = new Vector2(-1000, 0);
			this.enabled = false;
			
			exitSetting.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
			exitSetting.GetComponent<ExitGame>().enabled = true;
		}
	}
	
	void RefreshVisual() {
		for(int i=0;i<listMenu.Length;i++) {
			listMenu[i].GetComponent<Text>().color = new Color(1,1,1);
		}
		if (index == 0) {
			if (SaveLoadGame.SavedExist() == false)
				listMenu[index].GetComponent<Text>().color = new Color(0.47f,0.12f,0.12f);
			else listMenu[index].GetComponent<Text>().color = new Color(0.184f,0.67f,0.17f);
		} else listMenu[index].GetComponent<Text>().color = new Color(0.184f,0.67f,0.17f);
	}
	
	void MainScreenChoose() {
		if (index == 0) {
			if (SaveLoadGame.Load()) {
				Destroy(GameObject.Find("Sound"));
				DontDestroyOnLoad(GameObject.Find("Load From File"));
				Application.LoadLevel((string)SaveLoadGame.playerData.additionalData["Level"]);
			}
		}
		if (index == 1) Application.LoadLevel(2);
		if (index == 2) {
			this.GetComponent<RectTransform>().offsetMin = new Vector2(-1000, 0);
			this.enabled = false;
			
			mainSetting.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
			mainSetting.GetComponent<SettingMainMenu>().enabled = true;
		}
		if (index == 3) {
			this.GetComponent<RectTransform>().offsetMin = new Vector2(-1000, 0);
			this.enabled = false;
			
			exitSetting.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
			exitSetting.GetComponent<ExitGame>().enabled = true;
		}
	}
}
