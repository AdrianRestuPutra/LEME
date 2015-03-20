using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hunger : MonoBehaviour {
	public float maxHunger;
	public float hungerDecreased;
	public GameObject hungerLevel;
	
	private float hunger;
	private float second = 0;
	private Text text;
	
	// Use this for initialization
	void Start () {
		hunger = maxHunger;
		text = hungerLevel.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		second += Time.deltaTime;
		if (second >= hungerDecreased && hunger > 0) {
			second = 0;
			hunger--;
			
			if (hunger <= 0) PlayerDead();
		}
		
		text.text = hunger + "";
	}
	
	void PlayerDead() {
		
	}
	
	public void PlayerEat() {
		hunger = maxHunger;
	}
}
