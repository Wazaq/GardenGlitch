using UnityEngine;
using System.Collections;

public class Spawners : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	private GameTimer gametimer;

	void Start() {
		gametimer = GameObject.FindObjectOfType<GameTimer>();
	}
	// Update is called once per frame
	void Update () {
		if (gametimer.won == false && gametimer.buildTime == false) {
			foreach (GameObject thisAttacker in attackerPrefabArray) {
				if (isTimeToSpawn (thisAttacker)) {
					Spawn (thisAttacker);
				}
			}
		}
	}

	void Spawn (GameObject myGameObject) {
		GameObject myAttacker = Instantiate (myGameObject) as GameObject;
		myAttacker.transform.parent = transform;
		myAttacker.transform.position = transform.position;
	}

	bool isTimeToSpawn (GameObject attackerGameObject) {
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();

		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by Frame Rate");
			return false;
		}

		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		return (Random.value < threshold);		
	}
}
