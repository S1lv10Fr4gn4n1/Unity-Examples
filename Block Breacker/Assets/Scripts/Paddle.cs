using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float minX = 0.9f;
	public float maxX = 15.09f;
	private Ball ball;

	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
	}

	void Update() {
		if (!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}

	void MovePaddle(float positionX) {
		float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16);
		mousePosInBlocks = Mathf.Clamp(positionX, minX, maxX);
		this.transform.position = new Vector3(mousePosInBlocks, 0.5f, 0f);
	}

	void MoveWithMouse() {
		MovePaddle((Input.mousePosition.x / Screen.width * 16));
	}

	void AutoPlay() {
		MovePaddle(ball.gameObject.transform.position.x);
	}
}
