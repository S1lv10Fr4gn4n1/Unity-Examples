using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderController : MonoBehaviour {

	void Start() {
		SetUpLimit();
	}

	void SetUpLimit() {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));

		float width = Mathf.Abs(leftMost.x) + Mathf.Abs(rightMost.x);
		transform.localScale = new Vector3(width, transform.localScale.y);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Destroy(collider.gameObject);
	}
}
