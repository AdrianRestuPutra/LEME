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
		RefreshVisual();
	}
	
	void RefreshVisual() {
		textMesh.text = foodStock + " / " + maxFoodStock;
	}
	
	public bool PlayerEat() {
		if (foodStock > 0) {
			foodStock--;
			return true;
		} else return false;
	}
	
	public int GetFoodStock() {
		return foodStock;
	}
	
	public void SetFoodStock(int _foodStock) {
		foodStock = _foodStock;
	}
}
