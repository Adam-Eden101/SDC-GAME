using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour {

    public bool isWin;
    GameGenerator gameGenerator;

	// Use this for initialization
	void Start () {
        isWin = false;
        gameGenerator = GameObject.FindGameObjectWithTag("GameGenerator").GetComponent<GameGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        // this object was clicked - do something
        if (isWin)
        {
            gameGenerator.changeLetters();
            gameGenerator.playCorrectSound();
        } else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            //Debug.Log("RATÉ");
        }
    }

}
