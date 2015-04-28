using UnityEngine;
using UnityEngine.UI;
using Parse;
using System.Collections;

public class UsernameScript : MonoBehaviour {
	
	public GameObject keyboard;
	public GameObject keyboardSprite;
	
	private string username;
	private Keyboard _keyboard;
	private bool hasBeenSend = false;
	
	void Awake () {
		username = "";
		_keyboard = keyboard.GetComponent<Keyboard>();
	}
	
	// Use this for initialization
	void Start () {
		username = "";
		_keyboard = keyboard.GetComponent<Keyboard>();
	}
	
	// Update is called once per frame
	void Update () {
		InputManager();
		Visualize();
	}
	
	void InputManager() {
		bool input = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		bool backMainMenu = Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7) || 
			Input.GetKeyDown(KeyCode.Return);
		
		if (input && hasBeenSend == false) {
			string get = _keyboard.GetString();
			
			if (get.Equals("Space")) {
				if (username.Length < 15)
					username = username + " ";
			} else if (get.Equals("Delete")) {
				if (username.Length >= 1)
					username = username.Remove(username.Length - 1);
			} else if (get.Equals("Enter")) {
				GameObject mazetimer = GameObject.Find("Maze Timer");
				MazeTimer _mazetimer = mazetimer.GetComponent<MazeTimer>();
				ParseObject obj = new ParseObject(_mazetimer.stageName + "_Leaderboard");
				obj["userName"] = username;
				obj["timeMs"] = _mazetimer.GetMs();
				obj.SaveAsync();
				
				hasBeenSend = true;
				KeyboardDeleted();
			} else {
				if (username.Length < 15)
					username = username + get;
			}
		}
		
		if (hasBeenSend && backMainMenu)
			Application.LoadLevel("LevelSelection");
	}
	
	void Visualize() {
		if (!hasBeenSend)
			GetComponent<Text>().text = username + "_";
		else GetComponent<Text>().text = username; 
	}
	
	void KeyboardDeleted() {
		_keyboard.GetComponent<Keyboard>().enabled = false;
		for(int i=0;i<_keyboard.listLetter.Length;i++) {
			Destroy(_keyboard.listLetter[i]);
		}
		
		keyboardSprite.GetComponent<Image>().color =  new Color(1, 1, 1, 0.1f);
	}
}
