using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    private SpriteRenderer sprite;
    private AudioSource song;
    public Sprite on;
    public Sprite off;

    // Permet de gérer les éléments de fond dans la scène de départ
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        song = gameObject.GetComponent<AudioSource>();
    }

    // Permet d'éteindre et d'allumer la musique de fond avec un bouton
    void OnMouseDown()
    {
        if (sprite.sprite == on)
        {
            sprite.sprite = off;
            song.Pause();
        }
        else
        {
            sprite.sprite = on;
            song.UnPause();
        }
    }
}
