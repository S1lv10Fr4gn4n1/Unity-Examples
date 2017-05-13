using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGoalSound : MonoBehaviour {
	private AudioSource audioScore;

	void Start() {
		audioScore = GetComponent<AudioSource>();
		ScoreKeeper.AddListener(OnScored);
	}

	void OnDestroy() {
		ScoreKeeper.RemoveListener(OnScored);
	}

	void OnScored(int count) {
		audioScore.Play();
	}
}
