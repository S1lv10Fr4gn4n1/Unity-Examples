using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float speed = 0.3f;

    void FixedUpdate()
    {
        transform.Rotate(Quaternion.Euler(speed, speed, speed).eulerAngles);
    }
}
