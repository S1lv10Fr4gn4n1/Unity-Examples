using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
	public AudioClip[] levelMusicChange;

	private AudioSource audioSource;

	void Awake ()
	{
		audioSource = GetComponent<AudioSource> ();

		SceneManager.sceneLoaded += SceneLoaded;
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Don't destroy on load: " + name);
	}

	private void OnDestroy ()
	{
		SceneManager.sceneLoaded -= SceneLoaded;
	}

	void SceneLoaded (Scene scene, LoadSceneMode loadSceneMode)
	{
		AudioClip thisLevelMusic = levelMusicChange [scene.buildIndex];
		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}

	public void ChangeVolume (float volume)
	{
		audioSource.volume = volume;
	}
}
