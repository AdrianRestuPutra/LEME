using UnityEngine;
using System.Collections;

public class DigitCounterPuzzle : MonoBehaviour {

	public GameObject player;
	public int digitCount;
	public GameObject[] listDigit;
	public int[] digitSum;
	public GameObject penghalang;
	public string id;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<PlayerBag>().playerAdditionalData.ContainsKey(id)) {
			if (player.GetComponent<PlayerBag>().playerAdditionalData[id].Equals("Solved"))
				OpenDoor();
		}
		RefreshVisual();
		CheckFinished();
	}
	
	void RefreshVisual() {
		for(int i=0;i<digitCount;i++) {
			listDigit[i].GetComponent<TextMesh>().text = digitSum[i] + "";
		}
	}
	
	void CheckFinished() {
		bool zeroAll = true;
		for(int i=0;i<digitCount;i++) {
			zeroAll &= (digitSum[i] == 0);
		}
		
		if (zeroAll) {
			player.GetComponent<PlayerBag>().playerAdditionalData[id] = "Solved";
		}
	}
	
	void OpenDoor() {
		penghalang.GetComponent<SpriteRenderer>().enabled = true;
		penghalang.GetComponent<BoxCollider2D>().enabled = false;
		Destroy(GetComponent<DigitCounterPuzzle>());
	}
	
	public void AddDigit(int index, int sum) {
		digitSum[index] += sum;
		if (digitSum[index] == 2) digitSum[index] = -1;
		if (digitSum[index] == -2) digitSum[index] = 1;
	}
}
