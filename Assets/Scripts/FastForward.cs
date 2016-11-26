using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FastForward : MonoBehaviour {

	public bool speedUp = false;

	void SpeedUpTheGame() {
		if (speedUp) {
			Time.timeScale = 2;
		} else {
			Time.timeScale = 1;
		}
	}

}
