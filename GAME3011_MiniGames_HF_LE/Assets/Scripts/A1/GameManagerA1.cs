using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class GameManagerA1 : MonoBehaviour
{
    public static bool canExtract;
    public static bool canScan;
    public static int scans = 6;
    public static int extracts = 3;

    public TMP_Text scanText;
    public TMP_Text extractText;

    public void ScanPressed()
    {
        if(scans > 0)
        {
            canScan = true;
        }
        canExtract = false;
    }

    public void ExtractPressed()
    {
        if(extracts > 0)
        {
            canExtract = true;
        }
        canScan = false;
    }

    private void Update()
    {

        scanText.text = "Scan: " + scans;
        extractText.text = "Extract: " + extracts;

        if (extracts <= 0)
        {
            canExtract = false;
        }
        if(scans <= 0)
        {
            canScan = false;
        }
    }
}
