using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private int stars = 75;
	private Text currency;
	public enum Status {SUCCESS, FAILURE}

	// Use this for initialization
	void Start () {
		currency = GetComponent<Text>(); //Get the text componant so we can update it.
		currency.text = stars.ToString();
		UpdateDisplay();
	}

	public void AddStars (int amount) {
		stars += amount; // Add the stars to the Star Count
		UpdateDisplay();
	}

	public Status UseStars (int starCost) {
		if (stars >= starCost) {
			stars -= starCost;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}

	private void UpdateDisplay() {
		currency.text = stars.ToString();
	}
}
