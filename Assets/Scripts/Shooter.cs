using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator anim;
	private Spawners myLaneSpawners;

	void Start() {
		projectileParent = GameObject.Find ("Projectiles");
		anim = GameObject.FindObjectOfType<Animator>();

		// Creates a parent if necessary
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}

		SetMyLaneSpawner();
		//print (myLaneSpawners);

	}

	void Update() {
		if (IsAttackerAheadInLane()) {
			anim.SetBool ("isAttacking", true);
		} else {
			anim.SetBool ("isAttacking", false);
		}
	}

	// Look through all spawnwers and set myLaneSpawner if found
	void SetMyLaneSpawner () {
		Spawners[] spawnerArray = GameObject.FindObjectsOfType<Spawners>();

		foreach (Spawners spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawners = spawner;
				return;
			}
		}

	}

	bool IsAttackerAheadInLane() {
		// Exit if no attackers in lane
		if (myLaneSpawners.transform.childCount <= 0) {
			return false;
		}
		// If there are attackers, are they ahead of the defender?
		foreach (Transform attacker in myLaneSpawners.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		// Attacker in lane, but behind us
		return false;
	}

	private void Fire () {
		//GameObject newProjectile = Instantiate (projectile);
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;

	}
}
