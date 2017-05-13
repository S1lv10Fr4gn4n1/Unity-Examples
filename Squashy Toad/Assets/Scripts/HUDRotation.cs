using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDRotation : MonoBehaviour {

	Camera mainCamera;

	void Start() {
		mainCamera = transform.parent.GetComponentInChildren<Camera>();
	}

	void Update() {
		MoveHUD();
	}

	void MoveHUD() {
		var projectedLookDirection = Vector3.ProjectOnPlane(mainCamera.transform.forward, Vector3.up);
		Debug.DrawRay(transform.position, projectedLookDirection, Color.blue);

		var rotation = Quaternion.LookRotation(projectedLookDirection);
		transform.rotation = rotation;
	}
}
