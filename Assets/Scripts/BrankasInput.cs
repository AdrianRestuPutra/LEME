﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BrankasInput : MonoBehaviour {
	public GameObject player;
	public GameObject mainCamera;
	public GameObject brankas;
	public GameObject[] inputActive;
	public GameObject[] shownDigit;
	public int rightAnswer;
	public string objectInside;
	
	public GameObject hudChat;
	public string chatMessage;
	
	private int[] startDigit = new int[4];
	private int indexBrankas = 0;
	private string xboxBeforeH = "CENTER";
	private string xboxBeforeV = "CENTER";
	private float second = 0;
	

	// Use this for initialization
	void Start () {
		MoveYellowToRightPosition();
		for(int i=0;i<4;i++)
			startDigit[i] = 0;
			
		for(int i=0;i<4;i++)
			shownDigit[i].GetComponent<MeshRenderer>().sortingOrder = 12;
		
		player = GameObject.FindWithTag("Player");
		mainCamera = GameObject.FindWithTag("MainCamera");
		
		gameObject.transform.parent = mainCamera.transform;
		gameObject.transform.localPosition = new Vector3(0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		second += Time.deltaTime;
		if (second >= 0.5) {
			second = 0;
			xboxBeforeH = "CENTER";
			xboxBeforeV = "CENTER";
		}
		GetInputFromUser();
	}
	
	void GetInputFromUser() {
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
		
		if (left) indexBrankas = ((indexBrankas - 1) + 4) % 4;
		else if (right) indexBrankas = (indexBrankas + 1) % 4;
		
		if (up) AddDigit(indexBrankas, 1);
		else if (down) AddDigit(indexBrankas, -1);
		
		if (input) {
			int answer = GetAnswer();
			print (answer);
			if (answer == rightAnswer) {
				player.GetComponent<PlayerBag>().Collecting(objectInside);
				if (hudChat) {
					hudChat.GetComponent<Text>().text = chatMessage;
					//hudChat.GetComponent<Animator>().SetTrigger("StartFade");
					hudChat.GetComponent<Text>().color = new Color(0, 1, 0);
					hudChat.GetComponent<Animator>().Play("Fade HUD Chat", -1, 0);
				}
				print ("Jawaban Benar");
				RemoveBrankas();
			} else {
				if (hudChat) {
					hudChat.GetComponent<Text>().text = "Wrong code !";
					//hudChat.GetComponent<Animator>().SetTrigger("StartFade");
					hudChat.GetComponent<Text>().color = new Color(1, 0, 0);
					hudChat.GetComponent<Animator>().Play("Fade HUD Chat", -1, 0);
				}
				print ("Jawaban Salah");
			}
		}
		
		if (cancel) {
			RemoveBrankas();
		}
		
		if (left || right) MoveYellowToRightPosition();
	}
	
	void RemoveBrankas() {
		player.GetComponent<MovePlayer>().enabled = true;
		player.GetComponent<MovePlayer>().playerGraphic.GetComponent<Animator>().SetBool("Walk", false);
		brankas.GetComponent<Brankas>().enabled = true;
		Destroy(this.gameObject);
	}
	
	void MoveYellowToRightPosition() {
		for(int i=0;i<4;i++) inputActive[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
		inputActive[indexBrankas].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.31372549019f);
	}
	
	void AddDigit(int IndexBrankas, int Sum) {
		TextMesh textMesh = shownDigit[indexBrankas].GetComponent<TextMesh>();
		textMesh.text = (((startDigit[IndexBrankas] + Sum) + 10) % 10) + "";
		startDigit[IndexBrankas] = ((startDigit[IndexBrankas] + Sum) + 10) % 10;
	}
	
	int GetAnswer() {
		int ret = startDigit[0] * 1000 + startDigit[1] * 100 + startDigit[2] * 10 + startDigit[3];
		return ret;
	}
}
