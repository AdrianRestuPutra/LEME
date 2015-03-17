using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DateAndTime : MonoBehaviour {
	public int startDate;
	public string month;
	public int year;
	public float minuteInSecond;
	
	public int dayTime;
	
	private int hour = 0;
	private int minute = 0;
	private float second = 0;
	
	private Text text;
	
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		text.text = startDate + " " + month + " " + year + "\n" + "00 : 00" + "\n";
	}
	
	// Update is called once per frame
	void Update () {
		TimeChange();
	}
	
	void TimeChange() {
		second += Time.deltaTime;
		
		if (second >= minuteInSecond) {
			// A SECOND HAS PASSED
			second = 0;
			minute += 1;
			hour += (minute / 60);
			dayTime -= (minute / 60);
			startDate += (hour / 24);
			
			minute %= 60;
			hour %= 24;
			
			if (dayTime <= 0) OnTimeIsOver();
		}
		
		string hourString;
		string minuteString;
		
		if (hour < 10) hourString = "0" + hour;
		else hourString = hour + "";
		
		if (minute < 10) minuteString = "0" + minute;
		else minuteString = minute + "";
		
		if ((int)Time.timeSinceLevelLoad % 2 == 0)
			text.text = startDate + " " + month + " " + year + "\n" + hourString + " : " + minuteString + "\n";
		else text.text = startDate + " " + month + " " + year + "\n" + hourString + "   " + minuteString + "\n";
	}
	
	void OnTimeIsOver() {
		
	}
}
