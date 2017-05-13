using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehaviour : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start() {
		animator = GetComponent<Animator>();
	}

	// TODO try to find another way, warning on deploy says:
	// 		Game scripts or other custom code contains OnMouse_ event handlers.
	// 		Presence of such handlers might impact performance on handheld devices.
	void OnMouseDown() {
		animator.SetTrigger("Jump");
	}
}
