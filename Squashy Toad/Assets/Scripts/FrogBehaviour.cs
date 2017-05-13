using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FrogBehaviour : MonoBehaviour {

	private Rigidbody rigidBody;
	private Camera frogCamera;

	public float jumpElevationInDegree = 45f;
	public float[] jumpSpeedInMPS = { 1f, 2f, 3f };
	public float jumpHeight = 1f;
	public float speedTolerance = 5f;

	private int collisionCount = 0;
	private int hopCount = 0;

	void Start() {
		rigidBody = GetComponent<Rigidbody>();
		frogCamera = GetComponentInChildren<Camera>();
	}

	void Update() {
		HandleInputs();
	}

	void HandleInputs() {
		bool isOnGroudGround = collisionCount > 0;

		if (isOnGroudGround) {
			hopCount = 0;
		}

		if (GvrViewer.Instance.Triggered && hopCount < jumpSpeedInMPS.Length) {
			HandleTrigger();
			hopCount++;
		}
	}

	void HandleTrigger() {
		// show a vector to where the player is looking (forward)
		// Debug.DrawRay(transform.position, frogCamera.transform.forward, Color.red);

		var projectedLookDirection = Vector3.ProjectOnPlane(frogCamera.transform.forward, Vector3.up);
		// Debug.DrawRay(transform.position, projectedLookDirection, Color.blue);

		var radiansToRotate = Mathf.Deg2Rad * jumpElevationInDegree;
		var unnormalizedJumpDirection = Vector3.RotateTowards(projectedLookDirection, Vector3.up, radiansToRotate, 0);
		var jumpVector = unnormalizedJumpDirection.normalized * jumpSpeedInMPS[hopCount];
		// Debug.DrawRay(transform.position, jumpVector, Color.blue);

		rigidBody.AddForce(jumpVector, ForceMode.VelocityChange);
	}

	void OnCollisionEnter(Collision collision) {
		collisionCount++;
	}

	void OnCollisionExit(Collision collisionInfo) {
		collisionCount--;
	}
}
