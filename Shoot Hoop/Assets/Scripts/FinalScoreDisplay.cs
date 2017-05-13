using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreDisplay : MonoBehaviour {

	Text text;

	void Start() {
		text = GetComponent<Text>();
		int score = ScoreKeeper.GetFinalScore();
		text.text = "Score: " + score;
	}
}
