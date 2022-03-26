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
    public GameObject gameBoardPanel;
    public GameObject difficultyPanel;

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
        
        gameBoardPanel.SetActive(false);
        difficultyPanel.SetActive(false);
        
        numDesserts = 0;
        numDessertsToMatchText.text = numDesserts.ToString();
        
    }
    
    public void EasyMode()
    {
        easy = true;
        medium = false;
        hard = false;

        scoreToEarn = 150;
        scoreText.text = $" - / {scoreToEarn}";

        numDesserts = 3;
        numDessertsToMatchText.text = numDesserts.ToString();
        
        difficultyPanel.SetActive(false);
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
        gameBoardPanel.SetActive(true);
        
        timer.dessertTime = 45;
    }

    public void HardMode()
    {
        easy = false;
        medium = false;
        hard = true;

        scoreToEarn = 500;
        scoreText.text = $" - / {scoreToEarn}";

        numDesserts = 5;
        numDessertsToMatchText.text = numDesserts.ToString();
        
        difficultyPanel.SetActive(false);
        gameBoardPanel.SetActive(true);
        
        timer.dessertTime = 30;
    }
}
