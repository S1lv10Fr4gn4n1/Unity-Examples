using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour {

	float velocity = 10f;
	Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		rb.MovePosition(transform.position - transform.right * velocity * Time.deltaTime);	
	}
}
