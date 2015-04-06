using UnityEngine;
using System.Collections;

using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public static class SaveLoadGame {
	
	public static PlayerData playerData = new PlayerData();
	
	//it's static so we can call it from anywhere
	public static void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/LeMe.zd"); //you can call it anything you want
		bf.Serialize(file, playerData);
		file.Close();
	}   
	
	public static bool Load() {
		if(File.Exists(Application.persistentDataPath + "/LeMe.zd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/LeMe.zd", FileMode.Open);
			playerData = (PlayerData)bf.Deserialize(file);
			file.Close();
			return true;
		}
		return false;
	}
}
