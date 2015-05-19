using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LiftScript : MonoBehaviour {

	public GameObject[] lift;
	public GameObject[] selector;
	public GameObject selectorHUD;
	public GameObject player;
	
	private int index = 0;
	private string xboxBeforeV = "CENTER";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		InputManager();
	}
	
	void OnEnable () {
		selectorHUD.GetComponent<Image>().enabled = true;
	}
	
	void InputManager () {
		bool input = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button0);
	
		bool up = Input.GetKeyDown(KeyCode.UpArrow);
		bool down = Input.GetKeyDown(KeyCode.DownArrow);
		
		float vAxisXBOX = Input.GetAxis("Vertical_Joystick");
		
		if (vAxisXBOX >= 0.5 && xboxBeforeV != "UP") {
			up |= true;
			xboxBeforeV = "UP";
		} else if (vAxisXBOX <= -0.5 && xboxBeforeV != "DOWN") {
			down |= true;
			xboxBeforeV = "DOWN";
		} else if (vAxisXBOX == 0) xboxBeforeV = "CENTER";
		
		if (down) index = (index + 1) % selector.Length;
		else if (up) index = ((index - 1) + selector.Length) % selector.Length;
		
		if (input) {
			player.transform.position = lift[index].transform.position;
			for(int i=0;i<selector.Length;i++)
				selector[i].GetComponent<Image>().enabled = false;
			selectorHUD.GetComponent<Image>().enabled = false;
			player.GetComponent<MovePlayer>().enabled = true;
			for(int i=0;i<lift.Length;i++)
				lift[i].GetComponent<LiftDoorScript>().enabled = true;
			this.enabled = false;
		}
	}
	
	void FixedUpdate () {
		VisualizeSelector();
	}
	
	void VisualizeSelector () {
		for(int i=0;i<selector.Length;i++)
			selector[i].GetComponent<Image>().enabled = false;
		selector[index].GetComponent<Image>().enabled = true;
	}
}
