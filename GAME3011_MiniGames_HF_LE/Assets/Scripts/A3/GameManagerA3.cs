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
    public TMP_Text numToMatchText;

    [Header("UI's")]
    public GameObject gameBoardPanel;
    public GameObject difficultyPanel;

    [Header("Timer")]
    public DessertTimer timer;

    [Header("Score")]
    public int score;
    public TMP_Text scoreText;

    private void Awake()
    {
        gmA3Instance = this;
    }

    void Start()
    {
        gameBoardPanel.SetActive(false);
        difficultyPanel.SetActive(false);
        numDesserts = 0;
        numToMatchText.text = numDesserts.ToString();
        score = 0;
        scoreText.text = numDesserts.ToString();
        easy = false;
        medium = false;
        hard = false;
    }
    
    public void EasyMode()
    {
        easy = true;
        medium = false;
        hard = false;
        
        numDesserts = 3;
        score = 5;
        numToMatchText.text = numDesserts.ToString();
        difficultyPanel.SetActive(false);
        gameBoardPanel.SetActive(true);
        timer.dessertTime = 60;
    }

    public void MediumMode()
    {
        easy = false;
        medium = true;
        hard = false;

        numDesserts = 4;
        numToMatchText.text = numDesserts.ToString();
        difficultyPanel.SetActive(false);
        gameBoardPanel.SetActive(true);
        timer.dessertTime = 45;
    }

    public void HardMode()
    {
        easy = false;
        medium = false;
        hard = true;

        numDesserts = 5;
        numToMatchText.text = numDesserts.ToString();
        difficultyPanel.SetActive(false);
        gameBoardPanel.SetActive(true);
        timer.dessertTime = 30;
    }
}
