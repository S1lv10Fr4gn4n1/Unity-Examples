using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {

	public float timeTillNextLevel = 5.0f;

	public delegate void UpdateTimeRemainingDelegate(float timeRemaining);

	public static event UpdateTimeRemainingDelegate OnUpdateTimeRemainingDelegate;

	LevelManager levelManager;

	void Start() {
		levelManager = FindObjectOfType<LevelManager>();
		ScoreKeeper.ClearFinalScore();
	}

	void Update() {
		timeTillNextLevel -= Time.deltaTime;

		if (timeTillNextLevel <= 0) {
			GoToNextLevel();
		}

		if (OnUpdateTimeRemainingDelegate != null && timeTillNextLevel >= 0) {
			OnUpdateTimeRemainingDelegate(timeTillNextLevel);
		}
	}

	void GoToNextLevel() {
		levelManager.LoadScene("GameOver");	
	}

	public static void AddListener(UpdateTimeRemainingDelegate updateTimeRemainingDelegate) {
		OnUpdateTimeRemainingDelegate += updateTimeRemainingDelegate;
	}

	public static void RemoveListener(UpdateTimeRemainingDelegate updateTimeRemainingDelegate) {
		OnUpdateTimeRemainingDelegate -= updateTimeRemainingDelegate;
	}
}
