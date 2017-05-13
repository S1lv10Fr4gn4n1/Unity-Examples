using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public Text countText;
	public Text winText;

	public Rigidbody rb;
	public float speed;
	private int count;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		updateCountText ();
		winText.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}


	void OnTriggerEnter(Collider other)
	{
		GameObject gameObject = other.gameObject;
		if (gameObject.CompareTag ("Pick Up")) {
			gameObject.SetActive (false);
			count++;
			updateCountText ();
		}
	}

	void updateCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You win!";
		}
	}
}
