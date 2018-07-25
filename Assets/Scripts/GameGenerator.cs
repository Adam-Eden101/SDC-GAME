using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour {
    public int nb_letters;
    public GameObject letter;

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(letter);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
