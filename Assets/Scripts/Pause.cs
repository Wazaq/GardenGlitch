using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Pause : MonoBehaviour {

	public bool isPaused = false;

	private GameObject pauseScreen;



	void Start () {
		pauseScreen = GameObject.FindGameObjectWithTag("PauseScreen");
		pauseScreen.SetActive(false);

	}

	public void PauseScreen(bool isPaused) {
		if (isPaused) {
			pauseScreen.SetActive(true);
			Time.timeScale = 0;
		} else {
			pauseScreen.SetActive(false);
			Time.timeScale = 1;
		}
		
	}

}
