using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    public int nb_letters;
    public GameObject[] letters;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("changeLetters", 3.0f, 3.0f);
        letters = GameObject.FindGameObjectsWithTag("Letters");
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void changeLetters()
    {
        //TO CHANGE
        char letter_to_find = 'G';
        int nbr_of_letter_possibly_to_find = 1; // from 1 to 5

        // Init ressource needed before changin letters and needed only once
        IDictionary<char, GameObject[]> sprites = new Dictionary<char, GameObject[]>(); 
        for (char c = 'A'; c <= 'Z'; c++)
        {
            sprites[c] = GameObject.FindGameObjectsWithTag("Letter_" + c);
        }

        ////////////////////////////////////////////


        List<GameObject> sprite_to_render = new List<GameObject>();
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



        letters = GameObject.FindGameObjectsWithTag("Letters");
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
}