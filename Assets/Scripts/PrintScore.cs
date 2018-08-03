using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class PrintScore : MonoBehaviour {

    public Text goodAnswer;
    public Text badAnswer;
    public Text totalTime;
    public Text timeOuts;
    private ScoreClass score;

    [DllImport("__Internal")]
    private static extern void SendScore(int score);

	// Use this for initialization
	void Start () {
        	score = GameObject.FindGameObjectWithTag("ScoreObject").GetComponent<ScoreClass>();
			goodAnswer.text = score.goodAnswer.ToString() + " / 20";
			badAnswer.text = score.wrongAnswer.ToString() + " mauvaises réponses.";
			totalTime.text = score.countSeconds.ToString() + " secondes au total.";
			timeOuts.text = score.timeOut.ToString() + " timeouts.";
	       	SendScore(score.goodAnswer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
