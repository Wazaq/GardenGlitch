using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float waitTime;
	//public float autoLoadNextLevelAfter;

	private GameObject pauseScreen, speedColor;

	void Start() {
		pauseScreen = GameObject.FindGameObjectWithTag("PauseScreen");
		speedColor = GameObject.FindGameObjectWithTag("SpeedUp");
		Time.timeScale = 1; //This is so time can resume if we come here from the pause screen

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

	// Controll the speed up button
	public void SpeedUpTheGame(bool speedUp) {
		//Image color = GetComponent<Image>();

		if (speedUp) {
			Time.timeScale = 2;
			speedColor.GetComponent<Image>().color = Color.green;
			speedColor.GetComponentInChildren<Text>().text = "2X";
		} else {
			Time.timeScale = 1;			
			speedColor.GetComponent<Image>().color = Color.red;			
			speedColor.GetComponentInChildren<Text>().text = "1X";
		}
	}
}
