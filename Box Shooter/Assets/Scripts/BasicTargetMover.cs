using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTargetMover : MonoBehaviour {

    public float spinSpeed = 180.0f;
    public float motionMaginetude = 0.1f;
    public bool doSpin = true;
    public bool doMotion = false;

	void Update () {
        if (doSpin)
        {
            transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
        }
        
        if (doMotion) { 
            transform.Translate(Vector3.up * Mathf.Cos(Time.timeSinceLevelLoad) * motionMaginetude);
        }
    }
}
