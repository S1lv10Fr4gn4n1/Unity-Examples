using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour {

	public GameObject[] vehiclePrefabs;

	public float meanTime = 4f;
	public float minTime = 2f;

	float nextSpawnerTime = 0f;

	// Update is called once per frame
	void Update() {
		if (Time.time > nextSpawnerTime) {
			Spawn();
			nextSpawnerTime = Time.time + minTime - Mathf.Log(Random.value) * meanTime;
		}
	}

	void Spawn() {
		GameObject prefab = vehiclePrefabs[Random.Range(0, vehiclePrefabs.Length)];
		Instantiate(prefab, transform.position, transform.rotation, transform);
	}
}
