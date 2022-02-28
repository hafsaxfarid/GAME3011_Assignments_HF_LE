using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LockPickTimer : MonoBehaviour
{
    //display timer in scene
    public TextMeshProUGUI timerDisplay;

    public static float currentTime = 0.0f;
    [SerializeField] float startTime; //total amount of time on timer

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime; //update per second

        if (timerDisplay != null)
        {
            timerDisplay.SetText("Time Left: " + Mathf.Round(currentTime)); //round to whole number
        }

        if (currentTime <= 0)
        {
            //SceneManager.LoadScene("EndScene"); //once timer reaches 0 load endscene
        }
    }
}
