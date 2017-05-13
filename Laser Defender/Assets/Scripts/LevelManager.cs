using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private MusicPlayer musicPlayer;

	void Start() {
		musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
	}

	public void LoadLevel(string name) {
		Debug.Log("New Level load: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Debug.Log("Quit requested");
		Application.Quit();
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		musicPlayer.ChangeMusicByLevel(scene.name);
	}
}