using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {

	public GameObject treePrefab;

	void Start() {
		int totalTrees = Random.Range(2, 10);
		for (int i = 0; i < totalTrees; i++) {
			CreateRandomTree();
		}
	}

	void CreateRandomTree() {
		int x = Random.Range(-50, 50);
		int z = Random.Range(-5, 5);

		var tree = Instantiate(treePrefab) as GameObject;
		tree.transform.parent = transform;
		tree.transform.localPosition = new Vector3(x, 0, z);
	}
}
