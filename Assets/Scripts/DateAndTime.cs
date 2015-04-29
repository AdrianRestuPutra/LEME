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
	private int minuteFromBegining = 0;
	
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
	
	void FixedUpdate() {
		RefreshVisual();
	}
	
	void RefreshVisual() {
		string hourString;
		string minuteString;
		
		if (hour < 10) hourString = "0" + hour;
		else hourString = hour + "";
		
		if (minute < 10) minuteString = "0" + minute;
		else minuteString = minute + "";
		
		text.text = startDate + " " + month + " " + year + "\n" + hourString + " : " + minuteString + "\n";
	}
	
	void TimeChange() {
		second += Time.deltaTime;
		
		if (second >= minuteInSecond) {
			// A SECOND HAS PASSED
			second = 0;
			minute += 1;
			hour += (minute / 60);
			startDate += (hour / 24);
			
			minute %= 60;
			hour %= 24;
		}
	}
	
	public void SetDate(int _minute, int _hour, int _startDate) {
		minute = _minute;
		hour = _hour;
		startDate = _startDate;
	}
	
	public int GetMinute() {
		return minute;
	}
	
	public int GetHour() {
		return hour;
	}
	
	public int GetStartDate() {
		return startDate;
	}
}
