using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public GameObject laserPrefab;
	public float health = 150f;
	public float laserSpeed = 5f;
	public int scoreValue = 150;
	public AudioClip laserSound;
	public AudioClip deathSound;

	private ScoreKeeper scoreKeeper;

	void Start() {
		InitComponents();
		StartFiringMethod();
	}

	void InitComponents() {
		scoreKeeper = GameObject.Find("TextScoreValue").GetComponent<ScoreKeeper>();
	}

	void StartFiringMethod() {
		float randomFiring = Random.Range(0.5f, 3f);
		float randomStartFiring = Random.Range(0.5f, 2f);
		InvokeRepeating("FireLaser", randomStartFiring, randomFiring);
	}

	void FireLaser() {
		Vector3 startPosition = transform.position + new Vector3(0f, -0.7f);
		GameObject beam = Instantiate(laserPrefab, startPosition, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -laserSpeed);
		// play laser sound
		AudioSource.PlayClipAtPoint(laserSound, beam.transform.position);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		CheckCollitionWithProjectile(collider);	
	}

	void CheckCollitionWithProjectile(Collider2D collider) {
		Projectile projectile = collider.gameObject.GetComponent<Projectile>();
		if (projectile != null) {
			UpdateStatistics(projectile.GetDamage());
			UpdateGameObjects(projectile);
			CancelInvoke("FireLaser");
		}
	}

	void UpdateStatistics(int damage) {
		health -= damage;
		scoreKeeper.Score(scoreValue);
	}

	void UpdateGameObjects(Projectile projectile) {
		projectile.Hit();	
		if (health <= 0) {
			Die();
		}
	}

	void Die() {
		// play die sound
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
		Destroy(gameObject);
	}
}
