using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManagerA3 : MonoBehaviour
{
    public static GameManagerA3 gmA3Instance;

    [Header("Difficulties")]
    public static bool easy;
    public static bool medium;
    public static bool hard;

    [Header("Desserts to Match")]
    public int numDesserts;
    public TMP_Text numDessertsToMatchText;

    [Header("UI's")]
    public GameObject gamePanel; // whole game panel
    public GameObject gameBoardPanel; // just the board(with all the dessert tiles)
    public GameObject difficultyPanel;
    public GameObject gameWinPanel;

    [Header("Timer")]
    public DessertTimer timer;

    [Header("Score")]
    public int scoreToEarn;
    public int score;
    public TMP_Text scoreText;

    private void Awake()
    {
        gmA3Instance = this;
    }

    void Start()
    {
        easy = false;
        medium = false;
        hard = false;
        
        gamePanel.SetActive(false);
        gameBoardPanel.SetActive(false);
        difficultyPanel.SetActive(false);
        gameWinPanel.SetActive(false);
        
        numDesserts = 0;
        numDessertsToMatchText.text = numDesserts.ToString();
        
    }
    
    public void EasyMode()
    {
        easy = true;
        medium = false;
        hard = false;

        scoreToEarn = 25;
        scoreText.text = $" - / {scoreToEarn}";

        numDesserts = 3;
        numDessertsToMatchText.text = numDesserts.ToString();
        
        difficultyPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameBoardPanel.SetActive(true);

        timer.dessertTime = 60;
    }

    public void MediumMode()
    {
        easy = false;
        medium = true;
        hard = false;

        scoreToEarn = 300;
        scoreText.text = $" - / {scoreToEarn}";

        numDesserts = 4;
        numDessertsToMatchText.text = numDesserts.ToString();
        
        difficultyPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameBoardPanel.SetActive(true);

        timer.dessertTime = 45;
    }

    public void HardMode()
    {
        easy = false;
        medium = false;
        hard = true;

        scoreToEarn = 150;
        scoreText.text = $" - / {scoreToEarn}";

        numDesserts = 5;
        numDessertsToMatchText.text = numDesserts.ToString();
        
        difficultyPanel.SetActive(false);
        gamePanel.SetActive(true);
        gameBoardPanel.SetActive(true);

        timer.dessertTime = 30;
    }

    public void GameWin()
    {
        Time.timeScale = 0f;
        gameBoardPanel.SetActive(false);
        gameWinPanel.SetActive(true);
    }
}
