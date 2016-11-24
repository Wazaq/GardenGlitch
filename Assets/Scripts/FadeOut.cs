using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOut : MonoBehaviour {

	public float fadeOutTime;
	
	private Image fadePanel;
	//private Color currentColor = Color.black;
	//private Image panelController = GetComponent<Image>();
	
	// Use this for initialization
	void Start () {
		//Debug.Log ("This is: " + panelController);
		//panelController.CrossFadeAlpha(255f, fadeOutTime, false);
		//panelController.color(currentColor);

	}
	
	// Update is called once per frame
	void Update () {
		Image panelController = GetComponent<Image>();
		if (Time.timeSinceLevelLoad < fadeOutTime) {
			panelController.CrossFadeAlpha(0f, fadeOutTime, false);
		} else {

		}
		//Debug.Log (Time.time);
		gameObject.SetActive (false);
	}
}
