using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Boundary boundary;
	public float tilt;
	private Rigidbody rb;
	private AudioSource audioSource;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 0.1F;
	private float nextFire = 0.0F;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
		speed = 10.0f;
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.velocity = movement * speed;

		float x = Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax);
		float z = Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax);
		Vector3 position = new Vector3 (x, 0.0f, z);
		rb.position = position;

		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}

	// every frame
	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			audioSource.Play ();
		}
	}
}
