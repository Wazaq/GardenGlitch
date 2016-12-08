using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;	

	private Button[] buttonArray;
	private Text costText;
	private Defenders defenders;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		defenders = GameObject.FindObjectOfType<Defenders>(); 

		costText = GetComponentInChildren<Text>();
		if (!costText) {Debug.LogWarning (name + " has no cost ");}

		costText.text = defenderPrefab.GetComponent<Defenders>().starCost.ToString();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		//print (name + " pressed");

		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}

		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
		//print (selectedDefender);

	}
}
