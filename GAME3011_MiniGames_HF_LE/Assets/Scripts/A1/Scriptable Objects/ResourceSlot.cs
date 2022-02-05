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

    public Transform scanStartPoint;
    public float scanRange;
    public LayerMask tileLayer;

    public bool scanCircleActive = false;

    private int maxTileScanSize = 9;
    private void Start()
    {
        scanStartPoint.transform.position = transform.position;
        resourceIconTOP.enabled = true;
        resourceIconBOT.enabled = false;
        resourceAmount = resourceOnGrid.resourceAmount; //separate int cause scriptable objects keep the changed amount even after exiting scene.
    }

    private void Update()
    {

        if (resourceAmount == 5000)
        {
            resourceIconBOT.color = Color.red;
        }
        else if (resourceAmount == 2500)
        {
            resourceIconBOT.color = Color.blue;
        }
        else if (resourceAmount == 1250)
        {
            resourceIconBOT.color = Color.black;
        }
        else
        {
            resourceIconBOT.color = Color.grey;
        }

        if (resourceIconBOT.enabled)
        {
            isRevealed = true;
        }

        if (scanCircleActive == true)
        {
            tilesInRange();
        }
    }

    public void Pressed()
    {
        if (GameManager.canScan)
        {
            resourceIconTOP.enabled = false;
            resourceIconBOT.enabled = true;
            GameManager.scans--;
        }

        if (GameManager.canExtract)
        {
            if (isRevealed)
            {
                Extract();
            }
        }
    }

    void Extract()
    {
        if (resourceAmount != 0)
        {
            ResourcesCollected.resourcesCollected += resourceAmount;
            resourceAmount = 0;
            GameManager.extracts--;
        }
    }

    private void OnDrawGizmos()
    {
        if (isRevealed == true)
        {
            scanCircleActive = true;
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(scanStartPoint.transform.position, scanRange);
        }
    }

    private void tilesInRange()
    {
        Collider2D[] tilesInRange = Physics2D.OverlapCircleAll(scanStartPoint.transform.position, scanRange, tileLayer);
        scanCircleActive = false;


        foreach (Collider2D tile in tilesInRange)
        {
            if (tilesInRange.Length < maxTileScanSize || tilesInRange.Length == maxTileScanSize)
            {
                GameObject tempTile = tile.gameObject;
                tempTile.gameObject.GetComponent<ResourceSlot>().scanCircleActive = false;

                if (tempTile.CompareTag("Tile"))
                {
                    tempTile.gameObject.GetComponent<ResourceSlot>().scanCircleActive = false;
                    tempTile.gameObject.GetComponent<ResourceSlot>().resourceIconTOP.enabled = false;
                    tempTile.gameObject.GetComponent<ResourceSlot>().resourceIconBOT.enabled = true;
                    tempTile.gameObject.GetComponent<ResourceSlot>().isRevealed = true;

                }
                //Debug.Log("Tiles: " + tile);
            }
        }
    }
}
