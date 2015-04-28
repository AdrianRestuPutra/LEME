using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingMainMenu : MonoBehaviour {

	public GameObject[] listMenu;
	public bool isMainSetting;
	public bool isResolutionSetting;
	public bool isGraphicSetting;
	public bool isScreenSetting;
	public GameObject mainScreen;
	public GameObject mainSetting;
	public GameObject graphicSetting;
	public GameObject resolutionSetting;
	public GameObject screenSetting;
	
	private int index;
	private string xboxBeforeH = "CENTER";
	private string xboxBeforeV = "CENTER";

	// Use this for initialization
	void Start () {
		index = 0;
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
			if (isMainSetting) MainSettingChoose();
			if (isGraphicSetting) GraphicSettingChoose();
			if (isResolutionSetting) ResolutionSettingChoose();
			if (isScreenSetting) ScreenSettingChoose();
		}
		
		if (back) {
			if (isMainSetting) MainSettingBack();
			if (isGraphicSetting) GraphicSettingBack();
			if (isResolutionSetting) ResolutionSettingBack();
			if (isScreenSetting) ScreenSettingBack();
			index = 0;
		}
	}
	
	void RefreshVisual() {
		for(int i=0;i<listMenu.Length;i++) {
			listMenu[i].GetComponent<Text>().color = new Color(1,1,1);
		}
		
		listMenu[index].GetComponent<Text>().color = new Color(0.184f,0.67f,0.17f);
	}
	
	void MainSettingChoose() {
		if (index == 0) {
			this.GetComponent<RectTransform>().offsetMin = new Vector2(-1000, 0);
			this.enabled = false;
			
			graphicSetting.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
			graphicSetting.GetComponent<SettingMainMenu>().enabled = true;
		} else if (index == 1) {
			this.GetComponent<RectTransform>().offsetMin = new Vector3(-1000, 0);
			this.enabled = false;
			
			resolutionSetting.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
			resolutionSetting.GetComponent<SettingMainMenu>().enabled = true;
		} else if (index == 2) {
			this.GetComponent<RectTransform>().offsetMin = new Vector2(-1000, 0);
			this.enabled = false;
			
			screenSetting.GetComponent<RectTransform>().offsetMin = new Vector3(0, 0);
			screenSetting.GetComponent<SettingMainMenu>().enabled = true;
		}
	}
	
	void ResolutionSettingChoose() {
		if (index == 0) Screen.SetResolution(1366, 768, Screen.fullScreen);
		if (index == 1) Screen.SetResolution(1280, 800, Screen.fullScreen);
		if (index == 2) Screen.SetResolution(800, 600, Screen.fullScreen);
		if (index == 3) Screen.SetResolution(640, 480, Screen.fullScreen);
	}
	
	void GraphicSettingChoose() {
		QualitySettings.SetQualityLevel(index, true);
	}
	
	void ScreenSettingChoose() {
		if (index == 0) Screen.SetResolution(Screen.width, Screen.height, true);
		if (index == 1) Screen.SetResolution(Screen.width, Screen.height, false);
	}
	
	void MainSettingBack() {
		this.GetComponent<RectTransform>().offsetMin = new Vector2(-1000, 0);
		this.enabled = false;
		
		mainScreen.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
		mainScreen.GetComponent<MainMenu>().enabled = true;
	}
	
	void ResolutionSettingBack() {
		this.GetComponent<RectTransform>().offsetMin = new Vector2(-1000, 0);
		this.enabled = false;
		
		mainSetting.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
		mainSetting.GetComponent<SettingMainMenu>().enabled = true;
	}
	
	void GraphicSettingBack() {
		this.GetComponent<RectTransform>().offsetMin = new Vector2(-1000, 0);
		this.enabled = false;
		
		mainSetting.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
		mainSetting.GetComponent<SettingMainMenu>().enabled = true;
	}
	
	void ScreenSettingBack() {
		this.GetComponent<RectTransform>().offsetMin = new Vector2(-1000, 0);
		this.enabled = false;
		
		mainSetting.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
		mainSetting.GetComponent<SettingMainMenu>().enabled = true;
	}
}
