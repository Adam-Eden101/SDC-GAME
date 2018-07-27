using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour {
    public int                  max_turns;
    public int                  timer;
    public int                  nb_letters;
    private int                 curr_timer;
    private int                 turns = 0;
    private GameObject[]        letters;
    private GameObject[]        dismissed;
    private AudioSource         sound;

    // Use this for initialization
    void Start()
    {
        if (nb_letters < 5)
            nb_letters = 5;
        if (max_turns == 0)
            max_turns = 5;
        if (timer < 5)
        {
            timer = 5;
        }
        curr_timer = timer;
        InvokeRepeating("_main", 0, 2);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (turns <= max_turns)
        {
            if (curr_timer <= 0)
            {/*
                dismissed = GameObject.FindGameObjectsWithTag("Dismissed");
                _main();
                turns++;
                curr_timer = timer;*/
            }
        }
    }
    
    void decreaseTimer()
    {
        curr_timer--;
    }

    void _main()
    {
        dismissed = GameObject.FindGameObjectsWithTag("Dismissed");
        reinit();
        initLetters();
        turns++;
        curr_timer = timer;
    }

    void reinit()
    {
        dismissed = GameObject.FindGameObjectsWithTag("Dismissed");
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
        string letter = GetRandomLetter();

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

    public static string GetRandomLetter()
    {
        int num = Random.Range(0, 26);
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
