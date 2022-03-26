using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManagerA3 : MonoBehaviour
{
    [Header("Difficulties")]
    bool easy;
    bool medium;
    bool hard;

    [Header("Desserts to Match")]
    public int numDesserts;
    public TMP_Text numToMatchText;
    public GameObject gameBoardPanel;
    public GameObject difficultyPanel;
    public DessertTimer timer;
    
    void Start()
    {
        //gameBoardPanel.SetActive(false);
        difficultyPanel.SetActive(false);
        numDesserts = 0;
        numToMatchText.text = numDesserts.ToString();
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
