using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMan : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;

	Animator animator;
	Rigidbody2D rigidBody;


	// Use this for initialization
	void Start() {
		animator = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update() {
		
	}


	void FixedUpdate() {
		float move = Input.GetAxis("Horizontal");

		animator.SetFloat("Speed", Mathf.Abs(move));

		rigidBody.velocity = new Vector2(move * maxSpeed, rigidBody.velocity.y);

		if (move > 0 && facingRight) {
			Flip();
		} else if (move < 0 && !facingRight) {
			Flip();
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = this.transform.localScale;
		theScale.x *= -1;
		this.transform.localScale = theScale;
	}
}
