using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
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
        Debug.Log("A3 Coming Soon...");
    }

    public void LoadAssignment4()
    {
        Debug.Log("A4 Coming Soon...");
    }

    public void PlayAgain()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

}
