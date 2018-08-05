using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenController : MonoBehaviour {
    GameObject[] sprites_to_flip;

	// Use this for initialization
	void Start () {
        sprites_to_flip = GameObject.FindGameObjectsWithTag("Flip");
        InvokeRepeating("Flip", 0, 1f);
	}

    // Faire bouger les fleurs
    void Flip()
    {
        foreach (GameObject flipped in sprites_to_flip)
            flipped.GetComponent<SpriteRenderer>().flipX = !flipped.GetComponent<SpriteRenderer>().flipX;
    }

}
