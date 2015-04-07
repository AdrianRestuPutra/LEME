﻿using UnityEngine;
using System.Collections;

public class LevelSelectionScript : MonoBehaviour {
	
	public GameObject[] stagePicture;
	
	public GameObject stageName;
	public GameObject stageFloor;
	public GameObject stageDifficulties;
	public GameObject stageFoodStock;
	
	public string[] listName;
	public string[] listFloor;
	public string[] listDifficulties;
	public string[] listFoodStock;
	public int[] levelPuzzle;
	public int[] levelMaze;

	private int index;
	private string xboxBeforeH = "CENTER";

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
		bool left = Input.GetKeyDown(KeyCode.LeftArrow);
		bool right = Input.GetKeyDown(KeyCode.RightArrow);
		
		bool input = Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0);
		bool inputMaze = Input.GetKeyDown(KeyCode.Y) || Input.GetKeyDown(KeyCode.Joystick1Button3);
		
		bool back = Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Joystick1Button1)
			|| Input.GetKeyDown(KeyCode.Escape);
		
		float hAxisXBOX = Input.GetAxis("Horizontal_Joystick");
		
		if (hAxisXBOX >= 0.5 && xboxBeforeH != "RIGHT") {
			right |= true;
			xboxBeforeH = "RIGHT";
		} else if (hAxisXBOX <= -0.5 && xboxBeforeH != "LEFT") {
			left |= true;
			xboxBeforeH = "LEFT";
		} else if (hAxisXBOX == 0) xboxBeforeH = "CENTER";
		
		if (left) {
			index = ((index - 1) + stagePicture.Length) % stagePicture.Length;
		} else if (right) {
			index = (index + 1) % stagePicture.Length;
		}
		
		if (input) {
			Application.LoadLevel(levelPuzzle[index]);
		}
		
		if (inputMaze) {
			Application.LoadLevel(levelMaze[index]);
		}
		
		if (back) {
			Application.LoadLevel(1);
		}
	}
	
	void RefreshVisual() {
		for(int i=0;i<stagePicture.Length;i++) {
			stagePicture[i].GetComponent<SpriteRenderer>().enabled = false;
		}
		stagePicture[index].GetComponent<SpriteRenderer>().enabled = true;
		
		stageName.GetComponent<TextMesh>().text = listName[index];
		stageFloor.GetComponent<TextMesh>().text = listFloor[index];
		stageDifficulties.GetComponent<TextMesh>().text = listDifficulties[index];
		stageFoodStock.GetComponent<TextMesh>().text = listFoodStock[index];
	}
}
