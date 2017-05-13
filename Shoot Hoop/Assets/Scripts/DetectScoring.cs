using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectScoring : MonoBehaviour {

	public int targetScore = 1;
	private ScoreKeeper scoreKeeper;

	void Start() {
		scoreKeeper = FindObjectOfType<ScoreKeeper>();
	}

	void OnCollisionEnter(Collision collision) {
		scoreKeeper.IncrementScore(targetScore);
	}
}
