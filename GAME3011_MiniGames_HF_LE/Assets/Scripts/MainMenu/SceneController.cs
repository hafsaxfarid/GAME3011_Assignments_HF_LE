using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    public GameObject mainMenuPanel;
    public GameObject creditsPanel;
    public GameObject assignmentInfoPanel;

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
        assignmentInfoPanel.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadAssignment1()
    {
        SceneManager.LoadScene("OreMining");
    }

    public void LoadAssignment2()
    {
        SceneManager.LoadScene("LockPicking");
    }

    public void LoadAssignment3()
    {
        SceneManager.LoadScene("Match3");
    }

    public void MainMenuPanel()
    {
        mainMenuPanel.SetActive(true);
        assignmentInfoPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void CreditsPanel()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        assignmentInfoPanel.SetActive(false);
    }

    public void AssignInfoPanel()
    {
        assignmentInfoPanel.SetActive(true);
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
    }
    
    public void PlayAgain()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
