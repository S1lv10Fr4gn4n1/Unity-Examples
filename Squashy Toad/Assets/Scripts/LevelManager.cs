using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void LoadScene(string scene) {
		SceneManager.LoadScene(scene);
		Debug.Log("Load Scene " + scene);
	}

	public void Quit() {
		Application.Quit();
		Debug.Log("Quit Application");
	}
}
