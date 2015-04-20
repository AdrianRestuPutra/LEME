using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MazeTimerVisual : MonoBehaviour {

	public GameObject mazeTimer;

	private int hour = 0;
	private int minute = 0;
	private int second = 0;
	private int ms = 0;
	
	private Text text;

	// Use this for initialization
	void Start () {
		hour = 0;
		minute = 0;
		second = 0;
		ms = 0;
		text = GetComponent<Text>();
		text.text = hour + " : " + minute + " : " + second + " . " + ms;
	}
	
	// Update is called once per frame
	void Update () {
		ms = mazeTimer.GetComponent<MazeTimer>().GetMs();
		
		second = ms / 1000;
		minute = second / 60;
		hour = minute / 60;
		
		ms %= 1000;
		second %= 60;
		minute %= 60;
		
		string _hour;
		string _minute;
		string _second;
		
		if (second < 10) _second = "0" + second;
		else _second = second + "";
		
		if (minute < 10) _minute = "0" + minute;
		else _minute = minute + "";
		
		if (hour < 10) _hour = "0" + hour;
		else _hour = hour + "";
		
		text.text = _hour + " : " + _minute + " : " + _second + " . " + ms;
	}
}
