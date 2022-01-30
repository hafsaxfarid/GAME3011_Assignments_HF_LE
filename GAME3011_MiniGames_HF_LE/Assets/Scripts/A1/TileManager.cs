using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    public int row;
    public int column;

    public void setGridCoords(int r, int c)
    {
        row = r;
        column = c;
    }
}
