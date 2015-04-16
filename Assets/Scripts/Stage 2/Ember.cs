using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ember : MonoBehaviour {

	public GameObject player;
	public Sprite bucketFull;
	public Sprite bucketEmpty;
	
	private PlayerBag playerBag;

	// Use this for initialization
	void Start () {
		playerBag = player.GetComponent<PlayerBag>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerBag.playerBag.ContainsKey("Ember") == true) {
			if (playerBag.playerBag["Ember"].Equals("Isi"))
				GetComponent<Image>().sprite = bucketFull;
			else GetComponent<Image>().sprite = bucketEmpty;
		} else GetComponent<Image>().sprite = bucketEmpty;
	}
}
