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
		//Application.LoadLevel(4);
		failed.GetComponent<SpriteRenderer>().enabled = true;
		failed.GetComponent<Animator>().SetTrigger("Failed");
		failed.GetComponent<PassedOrFailed>().enabled = true;
		
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
}
