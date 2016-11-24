using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public float fadeInTime;

	private Image fadePanel;
	private Color currentColor = Color.black;
//	private Image panelController = GetComponent<Image>();

	// Use this for initialization
	void Start () {
		//Debug.Log ("This is: " + panelController);
		fadePanel = GetComponent<Image>();

	}
	
	// Update is called once per frame
	void Update () {
		//Image panelController = GetComponent<Image>();
		if (Time.timeSinceLevelLoad < fadeInTime) {
			float alphaChange = Time.deltaTime / fadeInTime;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
			//panelController.CrossFadeAlpha(0f, fadeInTime, false);
		} else {			
			gameObject.SetActive (false);
		}
	
	}
}
