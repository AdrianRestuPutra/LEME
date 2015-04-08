using UnityEngine;
using System.Collections;

public class LampBlink : MonoBehaviour {
	
	public float timeBlink;
	public int chanceBlink;
	public bool useIntensity;
	public float intensityBefore;
	public float intensityAfter;
	
	private float second = 0;
	private Light light;
	
	// Use this for initialization
	void Start () {
		second = 0;
		light = gameObject.GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		second += Time.deltaTime;
		if (second >= timeBlink) {
			second = 0;
			if (Random.Range(1, 101) <= chanceBlink) {
				if (!useIntensity) {
					if (light.enabled == true)
						light.enabled = false;
					else light.enabled = true;
				} else {
					if (light.intensity == intensityAfter)
						light.intensity = intensityBefore;
					else light.intensity = intensityAfter;
				}
			}
		}
	}
}
