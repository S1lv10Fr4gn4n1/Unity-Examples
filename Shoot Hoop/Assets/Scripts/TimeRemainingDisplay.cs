using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeRemainingDisplay : MonoBehaviour {

	private Text text;

	void Start() {
		text = GetComponent<Text>();
	}

	void OnEnable() {
		GameManager.AddListener(UpdateText);
	}

	void OnDisable() {
		GameManager.RemoveListener(UpdateText);
	}

	void UpdateText(float timeRemaining) {
		text.text = String.Format("{0:Time Remaining: 0.00}", timeRemaining);
	}

}
