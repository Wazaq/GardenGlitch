using UnityEngine;
using System.Collections;

public class GraveStone : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;

	void Start() {
		anim = GetComponent<Animator>();
		attacker = GameObject.FindObjectOfType<Attacker>();
	}
	//Only being used as a tag for now!!
	void OnTriggerStay2D(Collider2D collider) {
		if (attacker) {
			anim.SetTrigger("beingAttacked");
		}
	}
	
}