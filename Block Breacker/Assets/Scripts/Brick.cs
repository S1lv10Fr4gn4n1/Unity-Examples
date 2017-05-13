using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public static int breakableCount = 0;
	public int timesHit;
	public Sprite[] hitSprites;
	public AudioClip audioCrack;
	public GameObject smoke;

	private SpriteRenderer brickRenderer;
	private LevelManager levelManager;
	private bool isBreakable;

	void Start() {
		timesHit = 0;
		brickRenderer = GetComponent<SpriteRenderer>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();

		isBreakable = (this.tag == "Breakable");
		StartBreakableCount();
	}

	void StartSmock() {
		smoke.transform.position = this.transform.position;
	}

	void StartBreakableCount() {
		if (isBreakable) {
			breakableCount++;
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint(audioCrack, transform.position, 0.5f);
		if (isBreakable) {
			HandleHits();
		}
	}

	void HandleHits() {
		timesHit++;

		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			DestroyObject();
		} else {
			LoadSprintes();
		}
	}

	void LoadSprintes() {
		int indexSprite = timesHit - 1;
		Sprite sprite = hitSprites[indexSprite];
		if (sprite) {
			brickRenderer.sprite = sprite;
		} else {
			Debug.LogError("Missing sprint at " + indexSprite);
		}
	}

	void DestroyObject() {
		breakableCount--;
		levelManager.BlockDestroyed();
		TriggerSmock();
		Destroy(gameObject);
	}

	void TriggerSmock() {
		GameObject smockPuff = Instantiate(smoke, this.transform.position, Quaternion.identity);
		ParticleSystem particleSystem = smockPuff.GetComponent<ParticleSystem>();

		ParticleSystem.MinMaxGradient color = new ParticleSystem.MinMaxGradient();
		color.color = brickRenderer.color;

		var mainModule = particleSystem.main;
		mainModule.startColor = color;

		particleSystem.Play();
	}
}
