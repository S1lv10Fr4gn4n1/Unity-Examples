using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryGoalTrigger : MonoBehaviour {

	public int targetScore = 1;
	private Collider expectedCollider;
	private ScoreKeeper scoreKeeper;

	void Start() {
		scoreKeeper = FindObjectOfType<ScoreKeeper>();
	}

	public void ExpectCollider(Collider collider) {
		expectedCollider = collider;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider == expectedCollider) {			
			Scored();
		}
	}

	void Scored() {
		scoreKeeper.IncrementScore(targetScore);
	}
}
