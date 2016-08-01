using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	void Awake () {
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Dont destroy on load: " + name);
	}
	
	void Start(){
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log("Play clip: " + thisLevelMusic);
		
		if (thisLevelMusic){// If there is music attached
			audioSource.clip=thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}
	
	public void SetVolume(float volume){
		audioSource.volume = volume;
	}
}
