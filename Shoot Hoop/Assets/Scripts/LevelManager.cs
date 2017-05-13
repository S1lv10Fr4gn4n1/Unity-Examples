using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	
	public void LoadScene(string sceneName) {
		Debug.Log("Loading new scene " + sceneName);
		SceneManager.LoadScene(sceneName);
	}

	public void Quit() {
		Debug.Log("Quit Application");
		Application.Quit();
	}
}
