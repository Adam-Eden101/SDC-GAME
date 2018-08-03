using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameGenerator : MonoBehaviour
{
    public int              nb_letters;
    public int              max_turns;
    public float            waitTime;
    public Sprite           bgsprite2;
    public AudioSource      correctObject;

    private int             turnTimer;
    private int             turns = 0;
    private bool            gameAlive;
    private AudioSource     sound;
    private GameObject      timerObject;
    private GameObject[]    letters;
    private GameObject[]    dismissed;

    private ScoreClass      score;

    float                   timer;
    IDictionary<char, GameObject[]> sprites;

    // Use this for initialization
    void Start()
    {
        timerObject = GameObject.Find("Timer");
        score = GameObject.FindGameObjectWithTag("ScoreObject").GetComponent<ScoreClass>();
        turnTimer = (int)waitTime;
        timerObject.GetComponent<TextMeshProUGUI>().text = turnTimer.ToString();

        sprites = new Dictionary<char, GameObject[]>();

        // Permet de reset le score à 0 dans le cas où le joueur rejoue
        resetScore();

        // Remplissage du tableau de sprites
        for (char c = 'A'; c <= 'Z'; c++)
        {
            sprites[c] = GameObject.FindGameObjectsWithTag("Letter_" + c);
        }

        letters = GameObject.FindGameObjectsWithTag("Letters");

        // Initialisation des valeurs par défaut
        if (nb_letters < 5)
            nb_letters = 5;
        if (max_turns == 0)
            max_turns = 5;
        gameAlive = true;

        // On lance la boucle via changeLetter, puis on lance un timer
        Invoke("changeLetters", 0.25f);
        InvokeRepeating("timerIncrement", 1.25f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameAlive)
        {
            timer += Time.deltaTime;
            if (timer > waitTime)
            {
                // Si le timer expire, le joueur perd sur ce tour.
                // On change les lettres et on ajoute 1 au nombre de timeouts
                score.timeOut++;
                changeLetters();
            }
            if (turns >= max_turns)
            {
                // Si le nombre de tour souhaité est atteint, le jeu se termine
                endGame();
            }
        }
    }

    // On arrête la boucle, on garde l'objet GameScore et on change de scène
    void endGame()
    {
        CancelInvoke();
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("ScoreObject"));
        SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
    }

    // Petit sound effect en cas de réussite
    public void playCorrectSound()
    {
        correctObject.Play();
    }

    // 
    public void changeLetters()
    {
        timer = 0f;
        turnTimer = (int)waitTime;
        timerObject.GetComponent<TextMeshProUGUI>().text = turnTimer.ToString();
        
        // On récupère une chaise aléatoire et on joue le son associé
        char letter_to_find = GetRandomLetter();
        int nbr_of_letter_possibly_to_find = Random.Range(1, 5);
        List<GameObject> sprite_to_render = new List<GameObject>();
        playLetterSound(letter_to_find);
        
        // On donne des valeurs aux sprites
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

        // On récupère les bonnes lettres
        int nbr_sprite_letter_to_find = 0;
        foreach (GameObject tmp in sprites[letter_to_find])
        {
            nbr_sprite_letter_to_find++;
        }

        // On assigne les sprites aux bonnes lettres
        letters = GameObject.FindGameObjectsWithTag("Letter");
        int amount = 0;
        foreach (GameObject item in letters)
        {
            SpriteRenderer render = item.GetComponent<SpriteRenderer>();
            render.sprite = sprite_to_render[Random.Range(0, 100)].GetComponent<SpriteRenderer>().sprite;
            render.color = Color.white;
            item.GetComponent<LetterController>().isWin = false;
            amount++;
        }
        for (int n = 0; n < nbr_of_letter_possibly_to_find; n++)
        {
            int tmp = Random.Range(0, amount);
            letters[tmp].GetComponent<SpriteRenderer>().sprite = sprites[letter_to_find][Random.Range(0, nbr_sprite_letter_to_find)].GetComponent<SpriteRenderer>().sprite;
            letters[tmp].GetComponent<LetterController>().isWin = true;
        }

        // Au tour 10, on change de background
        if (turns == 10)
        {
            GameObject background;
            background = GameObject.Find("Background1");
            background.SetActive(false);

        }
        
        turns++;
    }

    static char GetRandomLetter()
    {
        int num = Random.Range(0, 26);
        char let = (char)('A' + num);
        return let;
    }

    void playLetterSound(char letter)
    {
        sound = (GameObject.Find("SoundObject")).GetComponent<AudioSource>();

        sound.clip = Resources.Load<AudioClip>(letter.ToString());
        Invoke("playLetter", 0.5f);
    }

    // playLetterSound et playLetter sont séparées pour pouvoir accéder à playLetter depuis un bouton "réécouter"
    public void playLetter()
    {
        sound.Play();
    }
    
    void timerIncrement()
    {
        turnTimer--;
        timerObject.GetComponent<TextMeshProUGUI>().text = turnTimer.ToString();
        score.countSeconds += 1;
    }

    // Réinitialisation du score
    void resetScore()
    {
        score.wrongAnswer = 0;
        score.goodAnswer = 0;
        score.timeOut = 0;
        score.countSeconds = 0;
    }
}