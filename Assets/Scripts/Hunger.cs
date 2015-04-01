using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hunger : MonoBehaviour {
	public float maxHunger;
	public float hungerDecreased;
	public GameObject hungerLevel;
	
	private float hunger;
	private float second = 0;
	private Slider slider;
	
	// Use this for initialization
	void Start () {
		hunger = maxHunger;
		slider = hungerLevel.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		second += Time.deltaTime;
		if (second >= hungerDecreased && hunger > 0) {
			second = 0;
			hunger--;
			
			if (hunger <= 0) PlayerDead();
		}
		
		slider.value = hunger;
	}
	
	void PlayerDead() {
		Application.LoadLevel(4);
	}
	
	public void PlayerEat() {
		hunger = maxHunger;
	}
}
