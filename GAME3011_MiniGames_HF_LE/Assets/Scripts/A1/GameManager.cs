using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool canExtract;
    public static bool canScan;
    public static int scans = 6;
    public static int extracts = 3;

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
}
