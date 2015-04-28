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
			
			string _ms;
			string _hour;
			string _minute;
			string _second;
			
			if (ms < 10) _ms = "00" + ms;
			else if (ms < 100) _ms = "0" + ms;
			else _ms = ms + "";
			
			if (second < 10) _second = "0" + second;
			else _second = second + "";
			
			if (minute < 10) _minute = "0" + minute;
			else _minute = minute + "";
			
			if (hour < 10) _hour = "0" + hour;
			else _hour = hour + "";
			
			text.text = hour + " : " + minute + " : " + second + " . " + _ms;
		}
	}
}
