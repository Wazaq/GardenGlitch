using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	private Vector3 placeDefender;
	private GameObject parent;
	private StarDisplay starDisplay;
	//private Defenders defenders;
	
	void Start() {
		//defenders = GameObject.FindObjectOfType<Defenders>();
		parent = GameObject.Find ("Defenders");
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		if (!parent) {
			parent = new GameObject("Defenders");
		}		
	}

	void OnMouseDown () {
		Vector2 rawPos = CalculateWorldPointOfMouseClick();
		Vector2 roundedPos = SnapToGrid (rawPos);
		placeDefender = SnapToGrid (CalculateWorldPointOfMouseClick());
		GameObject defender = Button.selectedDefender;
//		Debug.Log (CalculateWorldPointOfMouseClick());

		int defenderCost = defender.GetComponent<Defenders>().starCost;
		if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (defender);
		} else {
			Debug.Log ("Can't afford the defender");
		}
	}

	void SpawnDefender (GameObject defender)
	{
		Quaternion zeroRot = Quaternion.identity;
		if (Button.selectedDefender) {
			GameObject newDefender = Instantiate (defender, placeDefender, zeroRot) as GameObject;
			// Places the defender and Puts the defender under the Defenders in the Hiarch
			newDefender.transform.parent = parent.transform;
		}
		else {
			print ("Nothing is selected");
		}
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos) {
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2 (newX, newY);
	}

	Vector3 CalculateWorldPointOfMouseClick() {
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);

//		Debug.LogWarning("WorldPos is: " + worldPos);
		return worldPos;
	}
}
