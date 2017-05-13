using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance;

	void Awake() {
		if (instance == null) {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
}
