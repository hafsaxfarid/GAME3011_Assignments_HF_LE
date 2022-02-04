using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    public int row;
    
    [SerializeField]
    public int column;
    
    [SerializeField]
    public GameObject highlightedColor;

    public void setGridCoords(int r, int c)
    {
        row = r;
        column = c;
    }

    private void OnMouseEnter()
    {
        highlightedColor.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlightedColor.SetActive(false);
    }

    private void OnMouseDown()
    {
        Debug.Log("TO DO: Add options for scan or extract");
        //add option to scan
        //scan reveals second grid? (link individual tiles to each other?)
        //add extract option to second grid
    }
}
