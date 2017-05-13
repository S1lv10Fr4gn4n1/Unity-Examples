using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float shipSpeed = 12f;
	public float shipPadding = 1f;
	public GameObject laserPrefab;
	public float laserSpeed = 5f;
	public float firingRate = 0.2f;
	public int health = 300;
	public AudioClip laserSound;

	private float xMax = 5f;
	private float xMin = -5f;
	private PlayerHealth playerHealth;
	private LevelManager levelManager;

	void Start() {
		InitComponents();
		DefineMovementLimits();
	}

	void InitComponents() {
		playerHealth = GameObject.Find("TextPlayerHealthValue").GetComponent<PlayerHealth>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void DefineMovementLimits() {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));
		xMin = leftMost.x + shipPadding;
		xMax = rightMost.x - shipPadding;
	}

	// Update is called once per frame
	void Update() {
		HandleInput();
	}

	void HandleInput() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("FireLaser", 0.001f, firingRate);
		} else if (Input.GetKeyUp(KeyCode.Space)) {
			CancelInvoke("FireLaser");
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			MoveShipLeft();
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			MoveShipRight();
		}
	}

	void MoveShipLeft() {
		transform.position += Vector3.left * shipSpeed * Time.deltaTime;
		MoveShip();
	}

	void MoveShipRight() {
		transform.position += Vector3.right * shipSpeed * Time.deltaTime;
		MoveShip();
	}

	void MoveShip() {
		float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

	void FireLaser() {
		Vector3 startPosition = transform.position + new Vector3(0.0f, 0.7f);
		GameObject beam = Instantiate(laserPrefab, startPosition, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, laserSpeed);
		// fire laser sound
		AudioSource.PlayClipAtPoint(laserSound, beam.transform.position);
	}

	void OnTriggerEnter2D(Collider2D collider) {
		CheckCollisionWithProjectile(collider);
	}

	void CheckCollisionWithProjectile(Collider2D collider) {
		Projectile projectile = collider.gameObject.GetComponent<Projectile>();
		if (projectile != null) {
			UpdateStatistics(projectile.GetDamage());
			UpdateGameObjects(projectile);
		}
	}

	void UpdateStatistics(int damage) {
		playerHealth.Damage(damage);
		health -= damage;
	}

	void UpdateGameObjects(Projectile projectile) {
		projectile.Hit();

		// Die Player
		if (health <= 0) {
			Destroy(gameObject);
			levelManager.LoadLevel("End");
		}
	}
}
