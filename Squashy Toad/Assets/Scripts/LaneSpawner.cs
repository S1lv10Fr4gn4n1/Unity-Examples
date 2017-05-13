using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;


enum LaneType {
	Safe,
	Danger
}

public class LaneSpawner : MonoBehaviour {

	public GameObject[] safeLanePrefabs;
	public GameObject[] dangerLanePrefabs;
	public float saveLaneRunProbability = 0.2f;
	public int laneSpawnDistance = 100;
	public GameObject player;

	private LaneType lastLaneType = LaneType.Safe;
	private int offset = 0;

	void Update() {
		SpawnLanes();
		DestroyOldLanes();
	}

	void SpawnLanes() {
		while (offset < laneSpawnDistance + player.transform.position.z) {
			CreateRandomLane(offset);
			offset += 10;
		}
	}

	void DestroyOldLanes() {
		foreach (Transform lane in transform) {
			if (lane.transform.position.z + laneSpawnDistance < player.transform.position.z) {
				DestroyObject(lane.gameObject);
			}
		}
	}

	void CreateRandomLane(int offset) {
		GameObject lane = null;
		if (lastLaneType == LaneType.Safe) {
			if (Random.value < saveLaneRunProbability) {
				lane = InstantiateRandomLane(safeLanePrefabs);
				lastLaneType = LaneType.Safe;
			} else {
				lane = InstantiateRandomLane(dangerLanePrefabs);
				lastLaneType = LaneType.Danger;
			}
		} else {
			lane = InstantiateRandomLane(safeLanePrefabs);
			lastLaneType = LaneType.Safe;
		}
		lane.transform.parent = transform;
		lane.transform.Translate(0, 0, offset);
	}

	GameObject InstantiateRandomLane(GameObject[] lanes) {
		int laneIndex = Random.Range(0, lanes.Length);
		return Instantiate(lanes[laneIndex]) as GameObject;
	}
}
