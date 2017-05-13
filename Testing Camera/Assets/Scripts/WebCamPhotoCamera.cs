using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamPhotoCamera : MonoBehaviour {

	public RawImage display;
	private WebCamDevice[] devices;
	private WebCamTexture webCamTexture;
	private int deviceCameraIndex = 0;

	void Start() {
		devices = WebCamTexture.devices;

		if (devices.Length > 0) {
			int width = (int)display.rectTransform.rect.width;
			int height = (int)display.rectTransform.rect.height;
//			webCamTexture = new WebCamTexture(devices[deviceCameraIndex].name, width, height);
			webCamTexture = new WebCamTexture(devices[deviceCameraIndex].name);

//			float antiRotate = -(360 - webCamTexture.videoRotationAngle);
//			Quaternion quaternion = new Quaternion();
//			quaternion.eulerAngles = new Vector3(0f, 0f, antiRotate);
//			display.transform.rotation = quaternion;

			webCamTexture.Play();
		}

		display.texture = webCamTexture;
	}

	public void SwichCamera() {
		if (webCamTexture != null) {
			webCamTexture.Stop();
		}

		if (devices.Length > 0) {
			deviceCameraIndex++;
			deviceCameraIndex = deviceCameraIndex % devices.Length;
			webCamTexture.deviceName = devices[deviceCameraIndex].name;
			webCamTexture.Play();
		}
	}



	//	void Start() {
	//		webCamTexture = new WebCamTexture();
	//		renderer.material.mainTexture = webCamTexture;
	//		webCamTexture.Play();
	//	}
	//
	//	void TakePhoto() {
	//		// NOTE - you almost certainly have to do this here:
	//
	//		yield return new WaitForEndOfFrame();
	//
	//		// it's a rare case where the Unity doco is pretty clear,
	//		// http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
	//		// be sure to scroll down to the SECOND long example on that doco page
	//
	//		Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
	//		photo.SetPixels(webCamTexture.GetPixels());
	//		photo.Apply();
	//
	//		//Encode to a PNG
	//		byte[] bytes = photo.EncodeToPNG();
	//		//Write out the PNG. Of course you have to substitute your_path for something sensible
	//		File.WriteAllBytes(your_path + "photo.png", bytes);
	//	}
}
