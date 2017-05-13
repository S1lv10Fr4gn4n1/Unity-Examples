using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

    public string restartScene;

	// respond on collisions
	void OnCollisionEnter(Collision newCollision)
	{
		// only do stuff if hit by a projectile
		if (newCollision.gameObject.tag == "Projectile") {
            // call the RestartGame function in the game manager
            Application.LoadLevel(restartScene);
        }
	}
}
