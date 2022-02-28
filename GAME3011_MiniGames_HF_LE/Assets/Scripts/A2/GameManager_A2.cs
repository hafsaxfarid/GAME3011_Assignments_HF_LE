using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_A2 : MonoBehaviour
{

    public bool easy;
    public bool medium;
    public bool hard;
    public bool unlocked;

    [SerializeField]
    GameObject unlockedMessage;

    [SerializeField]
    LockPickTimer timer;

    [Range(0, 15)]
    public float playerSkill;

    [Range(1, 25)]
    public float lockDifficulty; //range of angle unlock. Higher = easier.

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
        if(unlocked)
        {
            unlockedMessage.SetActive(true);
        }
    }

    public void EasyMode()
    {
        easy = true;
        medium = false;
        hard = false;

        timer.startTime = 60;
        lockDifficulty = 30 + playerSkill;
    }

    public void MediumMode()
    {
        easy = false;
        medium = true;
        hard = false;

        timer.startTime = 40;
        lockDifficulty = 20 + playerSkill;
    }

    public void HardMode()
    {
        easy = false;
        medium = false;
        hard = true;

        timer.startTime = 20;
        lockDifficulty = 10 + playerSkill;
    }

    public void PlayerSkillSlider(float value)
    {
        playerSkill = value;
    }
}
