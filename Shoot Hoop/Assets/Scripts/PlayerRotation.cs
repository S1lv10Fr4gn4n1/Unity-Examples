using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

	public float rotationSpeed = 4.0f;
	private float mouseX;
	private float mouseY;
	private Camera playerCamera;

	void Start() {
		playerCamera = GetComponentInChildren<Camera>();
	}

	void Update() {
		mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
		mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

		transform.localRotation = Quaternion.Euler(0, mouseX, 0) * transform.localRotation;
		playerCamera.transform.localRotation = Quaternion.Euler(-mouseY, 0, 0) * playerCamera.transform.localRotation;
	}
}
