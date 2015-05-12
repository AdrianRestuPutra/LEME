using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parse;
using System.Collections;

public class LeaderboardScript : MonoBehaviour {

	public GameObject[] usernameList;
	public GameObject[] scoreList;
	
	private GameObject mazetimer;
	private MazeTimer _mazetimer;

	// Use this for initialization
	void Start () {
		mazetimer = GameObject.Find("Maze Timer");
		if (mazetimer)
			_mazetimer = mazetimer.GetComponent<MazeTimer>();
		
		StartCoroutine(CheckQuery());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator CheckQuery() {
		var query = ParseObject.GetQuery(_mazetimer.stageName + "_Leaderboard").OrderBy("timeMs").Limit(10);
		
		var task = query.FindAsync();
		while (!task.IsCompleted) yield return null;
		
		if (task.IsFaulted) {
			foreach(var e in task.Exception.InnerExceptions) {
				ParseException parseException = (ParseException) e;
				Debug.Log("Error message " + parseException.Message);
				Debug.Log("Error code: " + parseException.Code);
			}
		} else {
			var res = task.Result;
			int index = 0;
			foreach(ParseObject result in res) {
				print (result.Get<int>("timeMs") + " " + result.Get<string>("userName"));
				usernameList[index].GetComponent<Text>().text = result.Get<string>("userName");
				
				int ms = result.Get<int>("timeMs");
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
				
				scoreList[index].GetComponent<Text>().text = _hour + " : " + _minute + " : " + _second + " . " + _ms;
				index++;
			}
		}
	}
}
