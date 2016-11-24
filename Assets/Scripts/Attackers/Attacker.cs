using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;

	private float currentSpeed;
	private GameObject currentTarget, parent;
	private Animator anim; 

	// Use this for initialization
	void Start () {
		//Adds a rigid body 2D and makes it Kinematic
		Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
		myRigidBody.isKinematic = true;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//Moved the attackers to the left
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);

		//If the defender is killed, the attacker moves on
		if (!currentTarget) {
			anim.SetBool("isAttacking", false);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		//Debug.Log (name + " Attacker Collide!"); 
	}

	public void SetSpeed(float speed) {
		currentSpeed = speed; //speed is controlled in the animation
	}

	public void StrikeCurrentTarget (float damage) {
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage (damage);
			}
		}

	}

	// Called from animator at time of actual attack
	public void Attack (GameObject obj) {
		currentTarget = obj;


	}
}
