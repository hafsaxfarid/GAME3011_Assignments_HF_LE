using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ResourceSlot : MonoBehaviour
{
    public Resources resourceOnGrid;
    public Image resourceIconTOP;
    public Image resourceIconBOT;

    bool isRevealed = false;
    bool canExtract = false;
    int resourceAmount;

    private void Start()
    {
        resourceIconTOP.enabled = true;
        resourceIconBOT.enabled = false;
        resourceAmount = resourceOnGrid.resourceAmount; //separate int cause scriptable objects keep the changed amount even after exiting scene.
    }

    private void Update()
    {

        if(resourceAmount == 5000)
        {
            resourceIconBOT.color = Color.red;
        }
        else if(resourceAmount == 2500)
        {
            resourceIconBOT.color = Color.blue;
        }
        else if(resourceAmount == 1250)
        {
            resourceIconBOT.color = Color.black;
        }
        else
        {
            resourceIconBOT.color = Color.grey;
        }

        if(resourceIconBOT.enabled)
        {
            isRevealed = true;
        }

    }

    public void Pressed()
    {
        if(GameManager.canScan)
        {
            resourceIconTOP.enabled = false;
            resourceIconBOT.enabled = true;
            GameManager.scans--;
        }

        if(GameManager.canExtract)
        {
            if (isRevealed)
            {
                Extract();
            }
        }
    }

    void Extract()
    {
        if(resourceAmount != 0)
        {
            ResourcesCollected.resourcesCollected += resourceAmount;
            resourceAmount = 0;
            GameManager.extracts--;
        }
    }
}
