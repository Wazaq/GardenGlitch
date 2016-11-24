using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
[RequireComponent (typeof (Health))]
public class Lizard : MonoBehaviour {
	
	private Animator anim;
	private Attacker attacker;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		GameObject obj = collider.gameObject; //obj is the other guy
		
		//Leave the method if not colliding with defenders (finds script Defenders)
		if(!obj.GetComponent<Defenders>()) {
			return;
		} 
			anim.SetBool("isAttacking", true);
			attacker.Attack (obj);
	}
}
