using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class liée au bouton start
public class StartGame : MonoBehaviour {

    // lancer le jeu
    public void changeScene()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
