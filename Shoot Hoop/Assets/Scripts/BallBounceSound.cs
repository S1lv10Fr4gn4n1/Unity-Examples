using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounceSound : MonoBehaviour {

	private AudioSource audiosouce;

	void Start() {
		audiosouce = GetComponent<AudioSource>();		
	}

	void OnCollisionEnter(Collision collision) {
		audiosouce.Play();
	}
}
