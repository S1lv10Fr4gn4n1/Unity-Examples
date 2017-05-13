using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryGoalTrigger : MonoBehaviour {

	private SecondaryGoalTrigger secondaryGoalTrigger;

	void Start() {
		secondaryGoalTrigger = GetComponentInChildren<SecondaryGoalTrigger>();
	}

	void OnTriggerEnter(Collider collider) {
		secondaryGoalTrigger.ExpectCollider(collider);
	}
}
