using UnityEngine;
using System.Collections;

[System.Serializable]
public class SaveLoadGameScript : MonoBehaviour {

	public GameObject player;
	public GameObject food;
	public GameObject dateAndTime;
	public GameObject[] removedData;
	public string[] removeDataName;
	
	// Use this for initialization
	void Start () {
		if (GameObject.Find("Load From File")) {
			Destroy(GameObject.Find("Load From File"));
			
			player.transform.position = new Vector3((float)SaveLoadGame.playerData.additionalData["PositionX"],
			                                        (float)SaveLoadGame.playerData.additionalData["PositionY"],
			                                        player.transform.position.z);
			                                        
			player.GetComponent<PlayerBag>().playerBag = SaveLoadGame.playerData.playerBag;
			player.GetComponent<Hunger>().SetHunger((float)SaveLoadGame.playerData.additionalData["Hunger"]);
			player.GetComponent<PlayerBag>().playerAdditionalData = (Hashtable)SaveLoadGame.playerData.additionalData;
			food.GetComponent<FoodStock>().SetFoodStock((int)SaveLoadGame.playerData.additionalData["FoodStock"]);
			dateAndTime.GetComponent<DateAndTime>().SetDate(
				(int)SaveLoadGame.playerData.additionalData["MinuteDate"],
				(int)SaveLoadGame.playerData.additionalData["HourDate"],
				(int)SaveLoadGame.playerData.additionalData["StartDate"]
			);
		}
	}
	
	// Update is called once per frame
	void Update () {
		bool backMenu = Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7);
		
		if (backMenu) {
			SaveLoadGame.playerData.playerBag = player.GetComponent<PlayerBag>().playerBag;
			SaveLoadGame.playerData.additionalData["PositionX"] = player.transform.position.x;
			SaveLoadGame.playerData.additionalData["PositionY"] = player.transform.position.y;
			SaveLoadGame.playerData.additionalData["Hunger"] = player.GetComponent<Hunger>().GetHunger();
			SaveLoadGame.playerData.additionalData["FoodStock"] = food.GetComponent<FoodStock>().GetFoodStock();
			
			SaveLoadGame.playerData.additionalData["MinuteDate"] = dateAndTime.GetComponent<DateAndTime>().GetMinute();
			SaveLoadGame.playerData.additionalData["HourDate"] = dateAndTime.GetComponent<DateAndTime>().GetHour();
			SaveLoadGame.playerData.additionalData["StartDate"] = dateAndTime.GetComponent<DateAndTime>().GetStartDate();
			
			for(int i=0;i<removedData.Length;i++) {
				if (removedData[i] == null) {
					SaveLoadGame.playerData.additionalData[removeDataName[i]] = "Removed";
				}
			}
			
			SaveLoadGame.playerData.additionalData["Level"] = "Stage1";
			SaveLoadGame.Save();
		}
	}
}
