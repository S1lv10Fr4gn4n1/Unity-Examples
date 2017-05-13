using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHiddenPath : MonoBehaviour {

    bool playerIsIn = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Object " + collision.gameObject.name);
            playerIsIn = !playerIsIn;
            SetVisibility();
        }
    }

    void SetVisibility()
    {       
        Debug.Log("Player inside well " + playerIsIn);
        Color color;
        SpriteRenderer spriteRenderer;
        foreach (Transform child in transform.parent.transform)
        {
            spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                continue;
            }
            color = spriteRenderer.color;
            color.a = playerIsIn ? 0.4f : 1f;
            spriteRenderer.color = color;
        }
    }


}
