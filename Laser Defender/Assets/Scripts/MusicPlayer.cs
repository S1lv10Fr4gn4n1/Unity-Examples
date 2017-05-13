using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;

	private AudioSource music;

	void Start() {
		if (instance != null && instance != this) {
			Destroy(gameObject);
			print("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);

			music = GetComponent<AudioSource>();
			StartMusic();
		}	
	}

	void StartMusic() {
		music.clip = startClip;
		music.loop = true;
		music.Play();
	}

	public void ChangeMusicByLevel(string levelName) {
		Debug.Log("Music level " + levelName + " was loaded");

		if (!music) {
			return;
		}

		music.Stop();
		switch (levelName) {
			case "Menu":
				music.clip = startClip;
				break;
			case "Game":
				music.clip = gameClip;
				break;
			case "Win":
				music.clip = endClip;
				break;
		}

		music.Play();
	}
}