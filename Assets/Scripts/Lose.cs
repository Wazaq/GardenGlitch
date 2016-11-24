using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {

	private LevelManager levelManager;

	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager>(); 
	}

	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
		levelManager.LoadLevel("03b Lose");
		Debug.Log ("LoadLevel called");
	}
}
