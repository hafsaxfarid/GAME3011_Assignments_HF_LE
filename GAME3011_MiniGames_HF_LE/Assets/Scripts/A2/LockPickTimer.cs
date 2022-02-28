using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockPickTimer : MonoBehaviour
{
    public TextMeshProUGUI timerDisplay;
    public GameObject gameOver;

    public static float currentTime = 0.0f;
    public float startTime;

    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameManager_A2.unlocked)
        {
            currentTime -= 1 * Time.deltaTime; //update per second

            if (timerDisplay != null)
            {
                timerDisplay.SetText("Time Left: " + Mathf.Round(currentTime)); //round to whole number
            }

            if (currentTime <= 0)
            {
                currentTime = 0;
                gameOver.SetActive(true);
            }
        }
    }
}
