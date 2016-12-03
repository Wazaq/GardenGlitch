using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;


	void Awake() {
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Don't destroy on load: " +name);
	}

	void Start(){
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = levelMusicChangeArray[0]; //We set the clip to be the clip in the array
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
		audioSource.Play (); //We play the clip
	}
	
	void OnLevelWasLoaded(int level){
		Debug.Log ("Playing clip: " + levelMusicChangeArray[level]);
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		//audioSource.Stop (); //We stop the current music
		if (thisLevelMusic) { //Does this level have music?
			audioSource.clip = thisLevelMusic; //We set the clip to be the clip in the array
			audioSource.loop = true; //Let's loop it!
			audioSource.volume = 0.25f; //Lower the volume so we don't blow our ears out.
			audioSource.Play (); //We play the clip
		} else {
			Debug.Log ("This level does not have music: " +thisLevelMusic + " " + level);
		}
	}

	public void SetVolume (float volume) {
		audioSource.volume = volume;
	}
}


