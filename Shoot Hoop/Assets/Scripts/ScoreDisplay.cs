using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	Text textScore;

	void Start() {
		textScore = GetComponent<Text>();
	}

	void OnDisable() {
		ScoreKeeper.RemoveListener(UpdateTextScore);
	}

	void OnEnable() {
		ScoreKeeper.AddListener(UpdateTextScore);
	}

	void UpdateTextScore(int score) {
		textScore.text = "Score: " + score;
	}
}
