using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DessertTimer : MonoBehaviour
{
    public Slider timerSlider;
    public GameObject gameOverPanel;
    public float dessertTime;

    private float currentTime;
    private bool stopTime;

    void Start()
    {
        Time.timeScale = 1f;
        gameOverPanel.SetActive(false);
        currentTime = dessertTime;
        stopTime = false;
        timerSlider.maxValue = dessertTime;
        timerSlider.value = dessertTime;
    }

    void Update()
    {
        currentTime -= (1 * Time.deltaTime);
        
        if (currentTime <= 0)
        {
            currentTime = 0f;
            stopTime = true;
            GameOver();
        }
        
        if (stopTime == false)
        {
            timerSlider.value = currentTime;
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }
}
