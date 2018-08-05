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
        gameGenerator = GameObject.FindGameObjectWithTag("GameGenerator").GetComponent<GameGenerator>();

        isWin = false;
	}

    // Quand on appuie sur une lettre, on vérifie si la lettre est bonne ou non
    void OnMouseDown()
    {
        if (isWin)
        {
            // Si elle est bonne, on ajoute un point, on joue un petit son et on change les lettres
            score.goodAnswer += 1;
            gameGenerator.changeLetters();
            gameGenerator.playCorrectSound();
        } else {
            // Si elle est fausse, on la colorie en noir et on ajoute une mauvaise réponse
            GetComponent<SpriteRenderer>().color = Color.red;
            score.wrongAnswer += 1;
        }
    }

}
