using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour {
    public int                  nb_letters;
    private GameObject[]        letters;
    private GameObject[]        dismissed;
    private AudioSource          sound;

    // Use this for initialization
    void Start()
    {
        dismissed = GameObject.FindGameObjectsWithTag("Dismissed");
        InvokeRepeating("_main", 1.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
    }
    
    void _main()
    {
        reinit();
        if (nb_letters < 5)
            nb_letters = 5;
        initLetters();
        foreach (GameObject item in (GameObject.FindGameObjectsWithTag("Letter")))
        {
            //Debug.Log(item.name);
        }
    }

    void reinit()
    {
        Debug.Log(dismissed.Length);
        foreach (GameObject item in dismissed)
        {
            Debug.Log(item.name);
            item.tag = "Letter";
            item.SetActive(true);
        }

    }

    void initLetters()
    {
        int i = 0;
        sound = (GameObject.Find("SoundObject")).GetComponent<AudioSource>();
        string letter = GetLetter();
        sound.clip = Resources.Load<AudioClip>(letter);
        sound.Play();

        letters = GameObject.FindGameObjectsWithTag("Letter");
        reshuffle(letters);

        foreach (GameObject item in letters)
        {
            if (i >= nb_letters)
            {
                item.tag = "Dismissed";
            }
            i++;
        }

        dismissed = GameObject.FindGameObjectsWithTag("Dismissed");
        foreach (GameObject item in dismissed)
            item.SetActive(false);
    }

    public static string GetLetter()
    {
        // This method returns a random lowercase letter.
        // ... Between 'a' and 'z' inclusize.
        int num = Random.Range(0, 26); // Zero to 25
        char let = (char)('a' + num);
        return let.ToString();
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
