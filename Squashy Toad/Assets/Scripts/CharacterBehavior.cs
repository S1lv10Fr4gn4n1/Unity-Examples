using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour {

	public GameObject hud;
	public GvrReticlePointer reticle;
	public Rigidbody rb;

	void Start() {
		reticle = FindObjectOfType<GvrReticlePointer>();
		rb = GetComponent<Rigidbody>();
	}

	public void OnDeath() {
		hud.SetActive(true);
		reticle.enabled = true;
		rb.isKinematic = true;
	}
}
