using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerA3 : MonoBehaviour
{
    [Header("Difficulties")]
    bool easy;
    bool medium;
    bool hard;

    [Header("Desserts to Match")]
    public int numDesserts;
    public TMP_Text numToMatchText;

    void Start()
    {
        numDesserts = 0;
        numToMatchText.text = numDesserts.ToString();
        easy = false;
        medium = false;
        hard = false;
    }

    void Update()
    {
        
    }
    
    public void EasyMode()
    {
        numDesserts = 3;
        numToMatchText.text = numDesserts.ToString();

        easy = true;
        medium = false;
        hard = false;

        //timer.startTime = 60;
    }

    public void MediumMode()
    {
        numDesserts = 4;
        numToMatchText.text = numDesserts.ToString();

        easy = false;
        medium = true;
        hard = false;

        //timer.startTime = 40;
    }

    public void HardMode()
    {
        numDesserts = 5;
        numToMatchText.text = numDesserts.ToString();

        easy = false;
        medium = false;
        hard = true;

        //timer.startTime = 20;
    }
}
