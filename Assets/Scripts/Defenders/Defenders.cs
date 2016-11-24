using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Defenders : MonoBehaviour {

	private StarDisplay starDisplay;
	public int starCost = 50;

	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}


	public void AddStars (int amount) {
		starDisplay.AddStars (amount);
	}

	public void UseStars (int cost) {
		starDisplay.UseStars (cost);
	}

}