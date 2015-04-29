using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Hunger : MonoBehaviour {
	public float maxHunger;
	public float hungerDecreased;
	public GameObject hungerLevel;
	public GameObject failed;
	
	private float hunger;
	private float second = 0;
	private Slider slider;
	private float initialHungerDecreased;
	
	void Awake () {
		hunger = maxHunger;
		slider = hungerLevel.GetComponent<Slider>();
		initialHungerDecreased = hungerDecreased;
	}
	
	// Use this for initialization
	void Start () {
		
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
		//Application.LoadLevel(4);
		failed.GetComponent<SpriteRenderer>().enabled = true;
		failed.GetComponent<Animator>().SetTrigger("Failed");
		failed.GetComponent<PassedOrFailed>().enabled = true;
		
		GameObject.Find("Player Graphic").GetComponent<Animator>().SetBool("Walk", false);
		GetComponent<AudioSource>().enabled = false;
		
		Object[] objects = GameObject.FindObjectsOfType<GameObject>();
		foreach (Object _object in objects) {
			if (_object.Equals(failed) == false) {
				MonoBehaviour[] monoBehaviors = ((GameObject)_object).GetComponents<MonoBehaviour>();
				foreach(MonoBehaviour monoBehavior in monoBehaviors) {
					monoBehavior.enabled = false;
				}
			}
		}
	}
	
	public void PlayerEat() {
		hunger = maxHunger;
	}
	
	public void SetHunger(float _hunger) {
		hunger = _hunger;
	}
	
	public float GetHunger() {
		return hunger;
	}
	
	public void BoostMove() {
		hungerDecreased = initialHungerDecreased / 2f;
	}
	
	public void StandartMove() {
		hungerDecreased = initialHungerDecreased;
	}
}
