using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	private Rigidbody2D rigidBody;
	private AudioSource audioSource;

	void Start() {		
		paddle = GameObject.FindObjectOfType<Paddle>();
		audioSource = GetComponent<AudioSource>();
		rigidBody = GetComponent<Rigidbody2D>();

		paddleToBallVector = this.transform.position - paddle.transform.position;
	}

	void Update() {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown(0)) {
				hasStarted = true;
				rigidBody.velocity = new Vector2(2f, 10f);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if (hasStarted) {
			rigidBody.velocity += tweak;
			audioSource.Play();
		}
	}
}
