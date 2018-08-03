using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LetterController : MonoBehaviour {

    public bool isWin;
    GameGenerator gameGenerator;
    private ScoreClass score;

    // Use this for initialization
    void Start () {
        score = GameObject.FindGameObjectWithTag("ScoreObject").GetComponent<ScoreClass>();

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
            score.goodAnswer += 1;
            gameGenerator.changeLetters();
            gameGenerator.playCorrectSound();
        } else
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            score.wrongAnswer += 1;
        }
    }

}
