using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameManager_A2 : MonoBehaviour
{

    public bool easy;
    public bool medium;
    public bool hard;
    public static bool unlocked;

    [SerializeField]
    GameObject unlockedMessage;

    [SerializeField]
    LockPickTimer timer;

    [Range(0, 10)]
    public float playerSkill;

    //[Range(1, 25)]
    public float lockDifficulty; //range of angle unlock. Higher = easier.

    public Camera cam;
    public Transform innerLock;
    public Transform lockPickFollowTarget;
    public GameObject lockpick;

    public float lockPickMaxRotation = 90;
    public float lockpickSpeed = 10;

    float currentAngle;
    float unlockAngle;
    Vector2 unlockArea;
    float keyPressTime = 0;
    public bool canMoveLockpick = true;

    public AudioSource lockJiggle;
    public AudioSource unlockSound;
    public AudioSource clockTick;

    public GameObject fullLock;

    // Start is called before the first frame update
    void Start()
    {
        unlocked = false;
        easy = false;
        medium = false;
        hard = false;

        // unpause pause state
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        lockpick.transform.localPosition = lockPickFollowTarget.position;

        if(canMoveLockpick)
        {
            Vector3 direction = Input.mousePosition - cam.WorldToScreenPoint(lockpick.transform.position);
            currentAngle = Vector3.Angle(direction, Vector3.up);
            Vector3 cross = Vector3.Cross(Vector3.up, direction);
            if(cross.z < 0)
            {
                currentAngle = -currentAngle;
            }
            currentAngle = Mathf.Clamp(currentAngle, -lockPickMaxRotation, lockPickMaxRotation);
            Quaternion rotateTo = Quaternion.AngleAxis(currentAngle, Vector3.forward);
            lockpick.transform.rotation = rotateTo;
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            canMoveLockpick = false;
            keyPressTime = 1;

            // play lock jiggle
            lockJiggle.Play();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            canMoveLockpick = true;
            keyPressTime = 0;
            lockJiggle.Stop();
        }

        float percentage = Mathf.Round(100 - Mathf.Abs(((currentAngle - unlockAngle) / 100) * 100));
        float lockRotation = ((percentage / 100) * lockPickMaxRotation) * keyPressTime;
        float maxRotation = (percentage / 100) * lockPickMaxRotation;
        float lockLerp = Mathf.LerpAngle(innerLock.eulerAngles.z, lockRotation, Time.deltaTime * lockpickSpeed);
        innerLock.eulerAngles = new Vector3(0, 0, lockLerp);

        if(lockLerp >= maxRotation - 1)
        {
            if(currentAngle < unlockArea.y && currentAngle > unlockArea.x)
            {
                unlocked = true;

                CreateLock();
                canMoveLockpick = true;
                keyPressTime = 0;
            }
            else
            {
                float lockPickShake = Random.insideUnitCircle.x;
                lockpick.transform.eulerAngles += new Vector3(0, 0, Random.Range(-lockPickShake, lockPickShake));
            }
        }

        if (unlocked && LockPickTimer.currentTime != 0)
        {
            unlockedMessage.SetActive(true);
            clockTick.Stop();
            fullLock.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void EasyMode()
    {
        easy = true;
        medium = false;
        hard = false;

        timer.startTime = 60;
        lockDifficulty = 10 + playerSkill;

        CreateLock();
    }

    public void MediumMode()
    {
        easy = false;
        medium = true;
        hard = false;

        timer.startTime = 40;
        lockDifficulty = 5 + playerSkill;

        CreateLock();
    }

    public void HardMode()
    {
        easy = false;
        medium = false;
        hard = true;

        timer.startTime = 20;
        lockDifficulty = 1 + playerSkill;

        CreateLock();
    }

    void CreateLock()
    {
        unlockAngle = Random.Range(-lockPickMaxRotation + lockDifficulty, lockPickMaxRotation - lockDifficulty);
        unlockArea = new Vector2(unlockAngle - lockDifficulty, unlockAngle + lockDifficulty);

        Debug.Log(unlockArea);
    }

    public void PlayerSkillSlider(float value)
    {
        playerSkill = value;
    }
}
