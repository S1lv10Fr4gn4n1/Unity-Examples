using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5f;
	public float spawnDelay = 0.5f;

	private bool movingRight = true;
	private float xMax;
	private float xMin;

	void Start() {
		SetBoundaries();
		SpawnEnemiesAtPositions();
	}

	void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}

	void Update() {
		MovingSpawnBoundary();
		CheckGameEvolution();
	}

	void CheckGameEvolution() {
		if (AllMembersDead()) {
			ReSpawnEnemies();
		}
	}

	bool AllMembersDead() {
		foreach (Transform childPosition in transform) {
			if (childPosition.childCount > 0) {
				return false;
			}
		}
		return true;
	}

	void MovingSpawnBoundary() {
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}

		float rightEdge = transform.position.x + width / 2;
		float leftEdge = transform.position.x - width / 2;
		if (leftEdge < xMin) {
			movingRight = true;
		} else if (rightEdge > xMax) {
			movingRight = false;
		}
	}

	void SetBoundaries() {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
		Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));
		xMin = leftBoundary.x;
		xMax = rightBoundary.x;
	}

	void SpawnEnemiesAtPositions() {
		Transform freePosition = NextFreePosition();
		if (freePosition) {
			SpawnEnemyAtPosition(freePosition);
		}

		if (NextFreePosition()) {
			Invoke("SpawnEnemiesAtPositions", spawnDelay);
		}
	}

	void SpawnEnemyAtPosition(Transform spawnPosition) {
		GameObject enemy = Instantiate(enemyPrefab, spawnPosition.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = spawnPosition;
	}

	Transform NextFreePosition() {
		foreach (Transform childPosition in transform) {
			if (childPosition.childCount == 0) {
				return childPosition;
			}
		}
		return null;
	}

	void ReSpawnEnemies() {
		SpawnEnemiesAtPositions();
	}
}
