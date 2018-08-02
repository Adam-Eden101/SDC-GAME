using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenController : MonoBehaviour {
    GameObject[] flippeds;
	// Use this for initialization
	void Start () {
        flippeds = GameObject.FindGameObjectsWithTag("Flip");
        InvokeRepeating("Flip", 0, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Flip()
    {
        foreach (GameObject flipped in flippeds)
            flipped.GetComponent<SpriteRenderer>().flipX = !flipped.GetComponent<SpriteRenderer>().flipX;
    }

}
