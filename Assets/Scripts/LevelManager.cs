using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float waitTime;
	//public float autoLoadNextLevelAfter;

	void Start() {
		if (waitTime <= 0) {
			Debug.Log ("Level auto load disabled, use a positive number in seconds.");
		} else {
			Invoke ("LoadNextLevel", waitTime);
		}
	}

	public void LoadLevel(string name) {
		Debug.Log("Level Load request for: " + name);
		Application.LoadLevel(name);
	}

	public void QuitLevel() {
		Debug.Log("You have clicked the quit button");
		Application.Quit();
	}

	public void LoadNextLevel() {
		Application.LoadLevel(Application.loadedLevel + 1);
	}

}
