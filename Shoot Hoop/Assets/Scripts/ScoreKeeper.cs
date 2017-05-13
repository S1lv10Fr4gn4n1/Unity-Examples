using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreKeeper : MonoBehaviour {

	private const string KEY_FINAL_SCORE = "KEY_FINAL_SCORE";

	public delegate void UpdateScoreDelegate(int score);

	public static event UpdateScoreDelegate OnUpdateScoreDelegate;

	private int score = 0;

	public void IncrementScore(int targetScore) {
		score += targetScore;

		if (OnUpdateScoreDelegate != null) {
			OnUpdateScoreDelegate(score);
		}
	}

	void OnDestroy() {
		PlayerPrefs.SetInt(KEY_FINAL_SCORE, score);
		PlayerPrefs.Save();
	}

	public static int GetFinalScore() {
		return PlayerPrefs.GetInt(KEY_FINAL_SCORE);
	}

	public static void ClearFinalScore() {
		PlayerPrefs.DeleteKey(KEY_FINAL_SCORE);
	}

	public static void AddListener(UpdateScoreDelegate updateScoreDelegate) {
		OnUpdateScoreDelegate += updateScoreDelegate;
	}

	public static void RemoveListener(UpdateScoreDelegate updateScoreDelegate) {
		OnUpdateScoreDelegate -= updateScoreDelegate;
	}
}
