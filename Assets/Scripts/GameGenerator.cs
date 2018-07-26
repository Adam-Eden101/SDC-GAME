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
    private bool                gameAlive;

    // Use this for initialization
    void Start()
    {
        gameAlive = true;
        if (nb_letters < 5)
            nb_letters = 5;
        if (max_turns == 0)
            max_turns = 5;
        if (timer < 5)
        {
            timer = 5;
        }
        curr_timer = timer;
        InvokeRepeating("curr_timer", 0, 1.0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (turns <= max_turns)
        {
            if (curr_timer <= 0)
            {
                dismissed = GameObject.FindGameObjectsWithTag("Dismissed");
                _main();
                turns++;
                curr_timer = timer;
            }
        }
        else
        {
            gameAlive = false;0
        }
    }
    
    void decreaseTimer()
    {
        curr_timer--;
    }

    void _main()
    {
        reinit();
        initLetters();
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
