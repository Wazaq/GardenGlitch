using UnityEngine;
using System.Collections;

public class VolumeFixer : MonoBehaviour {

	private MusicManager musicManager;

	public float volume;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volume = PlayerPrefsManager.GetMasterVolume();
		
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.SetVolume (volume);
	}
}
