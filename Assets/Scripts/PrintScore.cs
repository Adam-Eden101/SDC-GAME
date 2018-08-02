using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintScore : MonoBehaviour {

    public Text goodAnswer;
    private ScoreClass score;

	// Use this for initialization
	void Start () {
        score = GameObject.FindGameObjectWithTag("ScoreObject").GetComponent<ScoreClass>();
        Debug.Log(score.goodAnswer);
        goodAnswer.text = score.goodAnswer.ToString() + " / 20";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
