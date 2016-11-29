using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	[Tooltip ("Game time in seconds, will covert to seconds")]
	public float levelTime; // How long the level will last in seconds
	public bool won = false; // controls if we won the level or not, public because it's being used by Spawners
	public bool buildTime = true; // Are we in Quiet Time at the start of the level?
	
	private Slider slider; // The level progress bar
	private AudioSource sound; // Winning game sound
	private Attacker attacker; // So we can tweak the difficulty as the level goes on.
	private LevelManager levelmanager;
	//private Spawner myLaneSpawners; //Watches the different lanes
	private GameObject winLabel; //The winning text
	private float quietTime = 10f; //10 seconds quiet time for player to get ready.

	// Use this for initialization
	void Start () {
		attacker = GameObject.FindObjectOfType<Attacker>();
		slider = gameObject.GetComponent<Slider>(); // Gets and sets the slider information for the level
		sound = GetComponent<AudioSource>(); // Get's the winning sound clip
		levelmanager = GameObject.FindObjectOfType<LevelManager>(); //Get's the levelmanager
		FindYouWin (); 
		winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (quietTime <= 0) {
			LevelCountdown();
		} else {
			quietTime -= Time.deltaTime;
		}
	}

	void FindYouWin ()
	{
		winLabel = GameObject.Find ("WinningText");
		//Get the winning text so we can display it;
		if (!winLabel) {
			Debug.LogWarning ("Please create Winning Text");
		}
	}

	void LevelCountdown() {
		//Once we win, this won't be called again causeing a crazy loop
		if (won == false) { // We have not won yet
			if (slider.value >= 1) {
				HandleWinCondition ();
			} else {
				slider.value += Time.deltaTime / levelTime; //using delta time becuase of the buildtime in the beginning of the level
				buildTime = false;
			}
		}

		// TODO: Now let's watch to see if there are any more attackers, if not, then we can end the level
	}

	void HandleWinCondition ()
	{
		DestroyAllTaggedObjects();
		won = true;
		sound.Play ();// Play the clip
		winLabel.SetActive (true);//Enable/show the winning text.
		Invoke ("WonLoadNextLevel", sound.clip.length);
	}

	// Destroy all objects when won so nothing runs in the background
	void DestroyAllTaggedObjects() {
		GameObject[] killAllArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
		foreach (GameObject killAll in killAllArray) {
			Destroy (killAll);
		}
	}

	void WonLoadNextLevel ()
	{
		levelmanager.LoadNextLevel ();
	}
}
