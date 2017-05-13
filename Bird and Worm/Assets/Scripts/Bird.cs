using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	private const string LEFT_DIRECTION = "left";
	private const string RIGHT_DIRECTION = "right";

	public GameObject wormDead;
	public GameObject wormLive;

	// Update is called once per frame
	void Update() {
		float moveX = 0.0f;
		float moveY = 0.0f;
		if (Input.GetKey(KeyCode.RightArrow)) {
			Flip(RIGHT_DIRECTION);
			moveX = 0.2f;
		} 
		if (Input.GetKey(KeyCode.LeftArrow)) {
			Flip(LEFT_DIRECTION);
			moveX = -0.2f;
		} 
		if (Input.GetKey(KeyCode.UpArrow)) {
			moveY = 0.2f;
		} 
		if (Input.GetKey(KeyCode.DownArrow)) {
			moveY = -0.2f;
		}

//		if (IsOutOfScreen()) {
//			return;
//		}
		this.transform.Translate(moveX, moveY, 0.0f);
	}

	//	bool IsOutOfScreen() {
	//		if (this.transform.position.x + 0.4f <= -6.5f || this.transform.position.x - 0.4f >= 7.0f) {
	//			return true;
	//		}
	//		if (this.transform.position.y - 0.4f <= -3.5f || this.transform.position.y - 0.4f >= 3.5f) {
	//			return true;
	//		}
	//		return false;
	//	}

	void Flip(string direction) {
		var localScale = this.transform.localScale;
		if (direction.Equals(RIGHT_DIRECTION)) {
			localScale.x = 1.0f;

		} else if (direction.Equals(LEFT_DIRECTION)) {
			localScale.x = -1.0f;
		}

		this.transform.localScale = localScale;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "WormLive") {
			wormLive.SetActive(false);
			wormDead.SetActive(true);
		}

		if (collision.gameObject.name == "LaunchTree") {
			wormLive.SetActive(true);
			wormDead.SetActive(false);
		}
	}
}
