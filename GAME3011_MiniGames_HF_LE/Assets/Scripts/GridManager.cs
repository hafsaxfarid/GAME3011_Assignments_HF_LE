using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    public int row;
    public int column;

    public GameObject tilePrefab;
    public GameObject[,] grid;

    public GameObject gridButton;

    private int gridSize;

    private void Start()
    {
        gridSize = (row * column);
        grid = new GameObject[row, column];
    }

    public void MakeGrid()
    {
        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < column; c++)
            {
                grid[r, c] = Instantiate(tilePrefab);
                grid[r, c].GetComponent<TileManager>().setGridCoords(r, c);
                grid[r, c].transform.position = new Vector3(r, c, 0);
            }
        }
        gridButton.SetActive(false);
    }
}
