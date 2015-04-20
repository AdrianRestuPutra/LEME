using UnityEngine;
using System.Collections;

public class MazeTimer : MonoBehaviour {

	public string stageName;

	private int millisecond = 0;
	private float timePassed = 0;
	private bool isTimerStop = false;

	void Awake () {
		millisecond = 0;
		timePassed = 0;
		isTimerStop = false;
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isTimerStop) {
			timePassed += Time.deltaTime;
			if (timePassed >= 0.01f) {
				millisecond += (int)(timePassed / 0.001f);
				timePassed = 0f;
			}
		}
	}
	
	public int GetMs() {
		return millisecond;
	}
	
	public void StopTimer() {
		isTimerStop = true;
	}
}
