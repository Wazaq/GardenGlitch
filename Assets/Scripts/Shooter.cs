using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	
	public GameObject projectile, gun;
	//public GameObject[] spawners;
	
	private GameObject projectileParent;
	private Animator anim;
	private GameObject myLaneSpawners;

	void Start() {
		projectileParent = GameObject.Find ("Projectiles");
		anim = GameObject.FindObjectOfType<Animator>();
		//spawners = GameObject.FindObjectsOfType<Spawner>();
		// Creates a parent if necessary
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
		SetMyLaneSpawner();
	}
	
	void Update() {
		if (IsAttackerAheadInLane()) {
			anim.SetBool ("isAttacking", true);
		} else {
			anim.SetBool ("isAttacking", false);
		}
	}

	void SetMyLaneSpawner () {
		
		// access the spawner[] in side the spawnerscript (which has 'Spawner' component attached)
		GameObject[] spawnerArray =  GameObject.FindObjectOfType<Spawner>().spawners;
		
		// the loop it for each of the spawner[] content. remember, array start from 0 but spawner.Length will start counting from 1. so we use 'less than'.
		for  (int i = 0; i < spawnerArray.Length; i++) {
			
			// if it find a game object from the array which have the same y position
			if (spawnerArray[i].transform.position.y == transform.position.y) {
				
				//set that gameobject as myLaneSpawners
				myLaneSpawners =  spawnerArray[i];
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
		if (attacker.transform.position.x > transform.position.x && attacker.transform.position.x < 10f) {
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