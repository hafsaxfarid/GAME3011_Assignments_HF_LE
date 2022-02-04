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

    public GameObject gameBoard;

    private int gridSize;

    private void Start()
    {
        gridSize = (row * column);
        grid = new GameObject[row, column];
        MakeGrid();
    }

    public void MakeGrid()
    {
        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < column; c++)
            {
                grid[r, c] = Instantiate(tilePrefab);
                grid[r, c].GetComponent<TileManager>().setGridCoords(r, c);
                grid[r, c].transform.parent = gameBoard.transform;
                grid[r, c].transform.position = new Vector3(r, c, 0);
                grid[r, c].transform.position = new Vector3( (gameBoard.transform.position.x -15.5f) + r, (gameBoard.transform.position.y - 15.5f) + c, 0);
            }
        }
    }






    ///copy of single grid
    //[SerializeField]
    //public int row;
    //public int column;
    //
    //public GameObject tilePrefab;
    //public GameObject[,] grid;
    //
    //public GameObject gameBoard;
    //
    //private int gridSize;
    //
    //private void Start()
    //{
    //    gridSize = (row * column);
    //    grid = new GameObject[row, column];
    //    MakeGrid();
    //}
    //
    //public void MakeGrid()
    //{
    //    for (int r = 0; r < row; r++)
    //    {
    //        for (int c = 0; c < column; c++)
    //        {
    //            grid[r, c] = Instantiate(tilePrefab);
    //            grid[r, c].GetComponent<TileManager>().setGridCoords(r, c);
    //            grid[r, c].transform.parent = gameBoard.transform;
    //            grid[r, c].transform.position = new Vector3(r, c, 0);
    //            grid[r, c].transform.position = new Vector3((gameBoard.transform.position.x - 15.5f) + r, (gameBoard.transform.position.y - 15.5f) + c, 0);
    //        }
    //    }
    //}
}


