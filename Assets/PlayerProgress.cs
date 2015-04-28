using UnityEngine;
using System.Collections;

using System.Collections.Generic; 
using System.Runtime.Serialization.Formatters.Binary; 
using System.IO;

public class PlayerProgress {

	public static PlayerProgressData playerProgress = new PlayerProgressData();
	
	//it's static so we can call it from anywhere
	public static void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/LeMeProg.zd"); //you can call it anything you want
		bf.Serialize(file, playerProgress);
		file.Close();
	}   
	
	public static bool Load() {
		if(File.Exists(Application.persistentDataPath + "/LeMeProg.zd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/LeMeProg.zd", FileMode.Open);
			playerProgress = (PlayerProgressData)bf.Deserialize(file);
			file.Close();
			return true;
		}
		return false;
	}
	
	public static bool SavedExist() {
		return File.Exists(Application.persistentDataPath + "/LeMeProg.zd");
	}
	
	public static bool StageSolved(string stageName) {
		if (playerProgress.playerProgress.ContainsKey(stageName) == false) return false;
		
		if (playerProgress.playerProgress[stageName].Equals("Solved"))
			return true;
		else return false;
	}
}
