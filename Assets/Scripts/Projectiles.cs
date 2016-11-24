using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

	public float speed, damage;

	
	//private GameObject currentTarget;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
	}

	void OnBecameInvisible() {
		Destroy (gameObject);
	}

	// When the projectile collides with the enemy
	void OnTriggerEnter2D(Collider2D collider) {
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		Health health = collider.gameObject.GetComponent<Health>();

		if (attacker && health) {
				health.DealDamage (damage);
				Destroy (gameObject);
		}
		//Debug.Log (name + " hit " + collider); 
	}
}
