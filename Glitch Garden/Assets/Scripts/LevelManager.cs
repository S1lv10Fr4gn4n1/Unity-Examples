using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    void Start()
    {
        if (autoLoadNextLevelAfter != 0)
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

    public void LoadLevel(string nameLevel) {
		Debug.Log("LoadScene scene " + nameLevel);
		SceneManager.LoadScene(nameLevel);
	}

	public void QuitGame() {
		Debug.Log("Quit Application");
		Application.Quit();
	}

	public void LoadNextLevel() {
		Debug.Log("Current Scene " + SceneManager.GetActiveScene().buildIndex);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
