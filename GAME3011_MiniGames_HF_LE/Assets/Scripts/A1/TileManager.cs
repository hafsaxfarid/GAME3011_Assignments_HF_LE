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

    private void OnMouseDown()
    {
        highlightedColor.SetActive(true);
        Debug.Log("Row: " + row + " Column: " + column);
    }

    private void OnMouseUp()
    {
        highlightedColor.SetActive(false);
    }
}