using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
	private const string SCORE = "SCORE";
	private int score = 0;
	private Text textScore;

	void Start() {
		textScore = GetComponent<Text>();
		LoadScore();
	}

	void OnDestroy() {
		PlayerPrefs.SetInt(SCORE, score);
		PlayerPrefs.Save();		
	}

	void LoadScore() {
		this.score = PlayerPrefs.GetInt(SCORE);
		UpdateText();
		Reset();
	}

	public void Score(int score) {
		this.score += score;
		UpdateText();
	}

	public void Reset() {
		this.score = 0;
		PlayerPrefs.DeleteKey(SCORE);
	}

	private void UpdateText() {
		textScore.text = score.ToString();
	}

	public int GetScore() {
		return PlayerPrefs.GetInt(SCORE);
	}
}
