using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour {
    public int          nb_letters;
    public GameObject[] letters;

    // Use this for initialization
    void Start ()
    {
        letters = GameObject.FindGameObjectsWithTag("Letter");
        foreach (GameObject item in letters)
        {
            Debug.Log(item.name);
        }
    }
	
	// Update is called once per frame
	void Update () {
		    
	}
}
