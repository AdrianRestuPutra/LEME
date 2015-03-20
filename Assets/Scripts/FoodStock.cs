using UnityEngine;
using System.Collections;

public class FoodStock : MonoBehaviour {

	public int maxFoodStock;
	
	private TextMesh textMesh;
	private int foodStock;

	// Use this for initialization
	void Start () {
		textMesh = this.gameObject.GetComponent<TextMesh>();
		foodStock = maxFoodStock;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public bool PlayerEat() {
		if (foodStock > 0) {
			foodStock--;
			textMesh.text = foodStock + " / " + maxFoodStock;
			return true;
		} else return false;
	}
}
