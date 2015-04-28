using UnityEngine;
using System.Collections;

public class MazeGenerator : MonoBehaviour {

	public GameObject player;
	public GameObject hudChat;
	public int roomTotal;
	public GameObject[] doorIn;
	public GameObject[] objectInRoom;

	private int nonLockedDoor;
	private ArrayList randomNumber = new ArrayList();
	
	// Use this for initialization
	void Start () {
		// SET RANDOMIZE
		for(int i=0;i<roomTotal;i++)
			randomNumber.Add(i);
		for(int i=0;i<1000;i++) {
			int x = Random.Range(0, roomTotal);
			int y = Random.Range(0, roomTotal);
			int temp = (int)randomNumber[x];
			randomNumber[x] = randomNumber[y];
			randomNumber[y] = temp;
		}
		nonLockedDoor = (int)randomNumber[0];
		
		// Nomor Room ke-0 itu gak dikunci
		for(int i=1;i<roomTotal;i++) {
			int lockedDoor = (int)randomNumber[i];
			doorIn[lockedDoor].GetComponent<ChangeRoom>().enabled = false;
		}
		
		SetKeyNeeded();
		SetKeyLocation();
		SetExitKey();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void SetKeyNeeded() {
		for(int i=1;i<roomTotal;i++) {
			int lockedDoor = (int)randomNumber[i];
			string key = lockedDoor + "-key";
			doorIn[lockedDoor].GetComponent<LockedDoorWithKey>().keyName = key;
		}
	}
	
	void SetKeyLocation() {
		for(int i=1;i<roomTotal;i++) {
			int lockedDoor = (int)randomNumber[i];
			int hideLocation = (int)randomNumber[i-1];
			string key = lockedDoor + "-key";
			
			GameObject[] listObject = objectInRoom[hideLocation].GetComponent<ObjectInRoom>().objectInRoom;
			
			int objectPlace = Random.Range(0, listObject.Length);
			GameObject selectedObject = listObject[objectPlace];
			
			selectedObject.AddComponent("CollectedItems");
			selectedObject.GetComponent<CollectedItems>().chatMessage = "A key has been found";
			selectedObject.GetComponent<CollectedItems>().hudChat = hudChat;
			selectedObject.GetComponent<CollectedItems>().player = player;
			selectedObject.GetComponent<CollectedItems>().objectName = key;
			selectedObject.GetComponent<HitObject>().isContainObject = true;
			
			objectInRoom[hideLocation].GetComponent<ObjectInRoom>().objectInRoom[objectPlace] = selectedObject;
		}
	}
	
	void SetExitKey() {
		int hideLocation = (int)randomNumber[roomTotal-1];
		string key = "exit-key";
		
		GameObject[] listObject = objectInRoom[hideLocation].GetComponent<ObjectInRoom>().objectInRoom;
		
		int objectPlace = Random.Range(0, listObject.Length);
		GameObject selectedObject = listObject[objectPlace];
		
		selectedObject.AddComponent("CollectedItems");
		selectedObject.GetComponent<CollectedItems>().chatMessage = "You found The Exit Key";
		selectedObject.GetComponent<CollectedItems>().hudChat = hudChat;
		selectedObject.GetComponent<CollectedItems>().player = player;
		selectedObject.GetComponent<CollectedItems>().objectName = key;
		
		objectInRoom[hideLocation].GetComponent<ObjectInRoom>().objectInRoom[objectPlace] = selectedObject;
	}
}
