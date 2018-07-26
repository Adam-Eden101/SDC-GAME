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
        reshuffle(letters);
        foreach (GameObject item in letters)
        {
            Debug.Log(item.name);
        }

    }
	
	// Update is called once per frame
	void Update () {

    }

    void reshuffle(GameObject[] array)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < array.Length; t++)
        {
            GameObject tmp = array[t];
            int r = Random.Range(t, array.Length);
            array[t] = array[r];
            array[r] = tmp;
        }
    }
}
