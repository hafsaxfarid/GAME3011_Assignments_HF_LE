using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool canExtract;
    public static bool canScan;

    public void ScanPressed()
    {
        canScan = true;
        canExtract = false;
    }

    public void ExtractPressed()
    {
        canExtract = true;
        canScan = false;
    }
}
