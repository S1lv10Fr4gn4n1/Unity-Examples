using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    float speed = 0.2f;

    void FixedUpdate()
    {
        transform.Rotate(Quaternion.Euler(speed, speed, speed).eulerAngles);
    }
}
