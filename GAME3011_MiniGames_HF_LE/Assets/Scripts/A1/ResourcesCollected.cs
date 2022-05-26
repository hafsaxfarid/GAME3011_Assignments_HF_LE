using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ResourcesCollected : MonoBehaviour
{
    public static int resourcesCollected;

    public TMP_Text resourcesCollectedText;
    public GameObject finalPanel;
    public TMP_Text finalText;

    // Start is called before the first frame update
    void Start()
    {
        resourcesCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        resourcesCollectedText.text = resourcesCollected.ToString();
        finalText.text = "You Collected: " + resourcesCollected + " Resources!";

        if(GameManagerA1.extracts <= 0)
        {
            finalPanel.SetActive(true);
        }
    }
}
