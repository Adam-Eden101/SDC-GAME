using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    private SpriteRenderer sprite;
    private AudioSource song;
    public Sprite on;
    public Sprite off;

    // Use this for initialization
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        song = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

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
