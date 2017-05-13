using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public void LoadLevel(string nameLevel) {
		SceneManager.LoadScene(nameLevel);
	}

	public void QuitGame() {
		Application.Quit();
		Debug.Log("Quit Game");
	}
}
