using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_A2 : MonoBehaviour
{

    public bool easy;
    public bool medium;
    public bool hard;

    // Start is called before the first frame update
    void Start()
    {
        easy = false;
        medium = false;
        hard = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EasyMode()
    {
        easy = true;
        medium = false;
        hard = false;
    }

    public void MediumMode()
    {
        easy = false;
        medium = true;
        hard = false;
    }

    public void HardMode()
    {
        easy = false;
        medium = false;
        hard = true;
    }
}
