using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lethal : MonoBehaviour {

	CharacterBehavior characterBehavior;

	void Start() {
		characterBehavior = FindObjectOfType<CharacterBehavior>();
	}

	void OnCollisionEnter(Collision collision) {
		characterBehavior.OnDeath();
	}
}
