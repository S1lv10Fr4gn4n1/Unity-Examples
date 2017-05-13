using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour {

	public GameObject ballPrefab;
	public float ballSpeed = 5.0f;

	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			CreateBall(Vector3.forward);
		}
	}

	private void CreateBall(Vector3 direction) {
		GameObject ball = Instantiate(ballPrefab);
		ball.transform.position = transform.position;

		Camera camera = GetComponentInChildren<Camera>();
		direction = camera.transform.rotation * direction;
		ball.GetComponent<Rigidbody>().velocity = direction * ballSpeed;
	}
}
