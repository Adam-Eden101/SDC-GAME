using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour {

    // Permet de rejouer (retourner à l'écran titre) à partir de la scène de fin
    public void Replay()
    {
        SceneManager.LoadScene("start", LoadSceneMode.Single);
    }
}
