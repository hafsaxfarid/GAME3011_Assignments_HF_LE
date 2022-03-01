using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class LockPickTimer : MonoBehaviour
{
    public TextMeshProUGUI timerDisplay;
    public GameObject gameOver;

    public static float currentTime = 0.0f;
    public float startTime;

    public AudioSource clockTick;

    void Start()
    {
        clockTick = GetComponent<AudioSource>();
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

                clockTick.Stop();

                Time.timeScale = 0f;
            }
        }
    }
}
