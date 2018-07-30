using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    public int                  nb_letters;
    private GameObject[]        letters;
    private GameObject[]        dismissed;
    public int                  max_turns;
    public int                  timer;
    private int                 curr_timer;
    private int                 turns = 0;
    private AudioSource         sound;
    private bool                gameAlive;

    IDictionary<char, GameObject[]> sprites;

    // Use this for initialization
    void Start()
    {
        // Init ressource needed before changin letters and needed only once
        sprites = new Dictionary<char, GameObject[]>();

        for (char c = 'A'; c <= 'Z'; c++)
        {
            sprites[c] = GameObject.FindGameObjectsWithTag("Letter_" + c);
        }

        letters = GameObject.FindGameObjectsWithTag("Letters");

        if (nb_letters < 5)
            nb_letters = 5;
        if (max_turns == 0)
            max_turns = 5;

        InvokeRepeating("changeLetters", 1.0f, 3.0f);
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void changeLetters()
    {
        //TO CHANGE
        char letter_to_find = GetRandomLetter();
        int nbr_of_letter_possibly_to_find = Random.Range(1, 5);

        List<GameObject> sprite_to_render = new List<GameObject>();

        playLetterSound(letter_to_find);


        for (int i = 0; i < 100; i++)
        {
            char c = GetRandomLetter();
            if (c != letter_to_find)
            {
                int size = 0;
                foreach (GameObject tmp in sprites[c])
                {
                    size++;
                }
                sprite_to_render.Add(sprites[c][Random.Range(0, size)]);
            }
            else
            {
                i--;
            }
        }

        int nbr_sprite_letter_to_find = 0;
        foreach (GameObject tmp in sprites[letter_to_find])
        {
            nbr_sprite_letter_to_find++;
        }
        
        letters = GameObject.FindGameObjectsWithTag("Letter");
        int amount = 0;
        foreach (GameObject item in letters)
        {
            SpriteRenderer render = item.GetComponent<SpriteRenderer>();
            render.sprite = sprite_to_render[Random.Range(0, 100)].GetComponent<SpriteRenderer>().sprite;
            amount++;
        }
        for (int n = 0; n < nbr_of_letter_possibly_to_find; n++)
        {
            letters[Random.Range(0, amount)].GetComponent<SpriteRenderer>().sprite = sprites[letter_to_find][Random.Range(0, nbr_sprite_letter_to_find)].GetComponent<SpriteRenderer>().sprite;
        }

    }

    static char GetRandomLetter()
    {
        int num = Random.Range(0, 26);
        char let = (char)('A' + num);
        return let;
    }

    void _main()
    {
        reinit();
        initLetters();
    }

    void reinit()
    {

        foreach (GameObject item in dismissed)
        {
            item.tag = "Letter";
            item.SetActive(true);
        }

    }

    void playLetterSound(char letter)
    {
        sound = (GameObject.Find("SoundObject")).GetComponent<AudioSource>();

        sound.clip = Resources.Load<AudioClip>(letter.ToString());
        sound.Play();
    }

    void initLetters()
    {
        int i = 0;

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