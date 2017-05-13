using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

public class CameraController : MonoBehaviour {

	public float maxBottomHeightCamera = -2.84f;
	public float maxTopHeightCamera = 9.2f;

	private float desktopMovimentCalibration = 0.8f;
	private float mobileMovimentCalibration = 0.2f;

	public static float fakeTrueHeading = 0.0f;

	void Start() {
		Input.gyro.enabled = true;
	}

	// Update is called once per frame
	void Update() {
		MoveCamera();
	}

	void OnDestroy() {
		Input.gyro.enabled = false;
	}

	void MoveCamera() {
		if (Camera.current != null) {
			float xAxisValue = 0.0f;
			float yAxisValue = 0.0f;

			if (SystemInfo.deviceType == DeviceType.Desktop) {
				xAxisValue = Input.GetAxis("Horizontal") * desktopMovimentCalibration;
				yAxisValue = Input.GetAxis("Vertical") * desktopMovimentCalibration;
			} else if (SystemInfo.deviceType == DeviceType.Handheld) {
				xAxisValue = -Input.gyro.rotationRateUnbiased.y * mobileMovimentCalibration;
				yAxisValue = Input.gyro.rotationRateUnbiased.x * mobileMovimentCalibration;
			}

			fakeTrueHeading += xAxisValue * 3;

			this.transform.Translate(xAxisValue, yAxisValue, 0.0f);

			float yPosition = Mathf.Clamp(transform.position.y, maxBottomHeightCamera, maxTopHeightCamera);
			this.transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
		}	
	}
}
