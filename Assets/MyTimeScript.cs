using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MyTimeScript : MonoBehaviour {

	private GameObject mazetimer;
	private MazeTimer _mazetimer;
	private Text text;

	// Use this for initialization
	void Start () {
		mazetimer = GameObject.Find("Maze Timer");
		if (mazetimer)
			_mazetimer = mazetimer.GetComponent<MazeTimer>();
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (mazetimer) {
			int ms = _mazetimer.GetMs();
			
			int second = ms / 1000;
			int minute = second / 60;
			int hour = minute / 60;
			
			ms %= 1000;
			second %= 60;
			minute %= 60;
			
			text.text = hour + " : " + minute + " : " + second + " . " + ms;
		}
	}
}
