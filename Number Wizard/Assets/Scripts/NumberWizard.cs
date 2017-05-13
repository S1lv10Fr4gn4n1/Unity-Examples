using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {
	int max;
	int min;

	int guess;
	int numberToBeGuess = -1;

	public int maxGuessesAllowed = 10;

	public Text guessText;
	public Text remainingText;

	void Start() {
		StartGame();
		NextGuess();
	}

	void StartGame() { 
		max = 1000;
		min = 1;
		numberToBeGuess = Random.Range(min, max + 1);
		guess = Random.Range(min, max + 1);
		Debug.Log("Guess number " + numberToBeGuess);

		max++;
	}

	public void GuessHigher() {
		min = guess;
		NextGuess();
	}

	public void GuessLower() {
		max = guess;
		NextGuess();
	}

	void NextGuess() {
		guess = Random.Range(min, max + 1);
		Debug.Log("min: " + min + ", max: " + max + ", guess: " + guess);
		maxGuessesAllowed--;

		UpdateTexts();

		if (isCorrectGuess()) {
			WinGame();
		} else if (maxGuessesAllowed <= 0) {
			LoseGame();
		}
	}

	void UpdateTexts() {
		guessText.text = guess.ToString();
		remainingText.text = maxGuessesAllowed.ToString();
	}

	bool isCorrectGuess() {
		return numberToBeGuess == guess;			
	}

	void WinGame() {
		SceneManager.LoadScene("Win");
	}

	void LoseGame() {
		SceneManager.LoadScene("Lose");
	}
}
