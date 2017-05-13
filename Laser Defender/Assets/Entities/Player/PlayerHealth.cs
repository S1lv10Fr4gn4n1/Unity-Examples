using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	private int startHealth = 300;
	private int health;
	private Text textHealth;

	void Start() {
		InitComponents();
		InitHealth();
	}

	void InitHealth() {
		health = startHealth;
		UpdateText();
	}

	void InitComponents() {
		textHealth = GetComponent<Text>();
	}

	public void Damage(int damage) {
		this.health -= damage;
		UpdateText();
	}

	public void Reset() {
		this.health = startHealth;
	}

	void UpdateText() {
		textHealth.text = health.ToString();
	}
}
