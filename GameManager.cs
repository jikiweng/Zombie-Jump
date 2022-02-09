using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject mainMenuPhoto;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject scoreObject2;
    [SerializeField] private GameObject highScoreObject;
    [SerializeField] private GameObject scoreObject;
    [SerializeField] private GameObject newRecord;
    [SerializeField] private GameObject scoreBoard;

    private bool playerActive = false;
    private bool gameOver = false;
    private bool gameStarted = false;
    private int score=0;
    private int highScore = 0;

    public bool PlayerActive
    {
        get { return playerActive; }
    }
    public bool GameOver
    {
        get { return gameOver; }
    }
    public bool GameStarted
    {
        get { return gameStarted; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        Assert.IsNotNull(mainMenu);
        Assert.IsNotNull(mainMenuPhoto);
        Assert.IsNotNull(gameOverMenu);
        Assert.IsNotNull(newRecord);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerCollided()
    {
        gameOver = true;
        gameOverMenu.SetActive(true);
        scoreBoard.SetActive(false);

        if (score > highScore)
        {
            highScore = score;
            newRecord.SetActive(true);
        }
        else
            newRecord.SetActive(false);

        Text scoreText2 = scoreObject2.GetComponent<Text>();
        scoreText2.text = "     Score: " + score;
        Text highScoreText = highScoreObject.GetComponent<Text>();
        highScoreText.text = "Best Score: " + highScore;
    }

    public void PlayerStartGame()
    {
        playerActive = true;
    }
    public void EnterGame()
    {
        mainMenu.SetActive(false);
        mainMenuPhoto.SetActive(false);
        gameStarted = true;
    }

    public void RestartGame()
    {
        gameOver = false;
        gameOverMenu.SetActive(false);
        scoreBoard.SetActive(true);

        score = -1;
        instance.CollectCoin();
        playerActive = false;
    }

    public void CollectCoin()
    {
        score += 1;
        Text scoreText = scoreObject.GetComponent<Text>();
        scoreText.text = "Score: " + score;
    }
}
