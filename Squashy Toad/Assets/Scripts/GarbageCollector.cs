using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		DestroyObject(collider.gameObject);
	}
	
}
