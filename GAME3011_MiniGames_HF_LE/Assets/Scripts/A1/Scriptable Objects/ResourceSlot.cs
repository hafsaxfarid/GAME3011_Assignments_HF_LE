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

    private void Start()
    {
        resourceIconTOP.enabled = true;
        resourceIconBOT.enabled = false;
    }

    private void Update()
    {
        if(resourceOnGrid.resourceAmount == 5000)
        {
            resourceIconBOT.color = Color.red;
        }
        else if(resourceOnGrid.resourceAmount == 2500)
        {
            resourceIconBOT.color = Color.blue;
        }
        else if(resourceOnGrid.resourceAmount == 1250)
        {
            resourceIconBOT.color = Color.black;
        }
        else
        {
            resourceIconBOT.color = Color.white;
        }
    }

    public void Pressed()
    {
        resourceIconTOP.enabled = false;
        resourceIconBOT.enabled = true;
    }
}
