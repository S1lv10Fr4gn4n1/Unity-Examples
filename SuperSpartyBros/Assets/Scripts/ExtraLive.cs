using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLive : MonoBehaviour {

    GameManager gameManager;
    public GameObject explosion;

    void Start () {
        gameManager = FindObjectOfType<GameManager>();
	}


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.AddExtraLive();

            if (explosion)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }

            AudioSource audioSource = GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(audioSource.clip, transform.position, 2f);
            
            Destroy(gameObject);
        }
    }

}
