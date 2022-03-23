using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager gridManagerInstance;
    public List<Sprite> desserts = new List<Sprite>();

    public GameObject dessertTile;
    public int xSize;
    public int ySize;

    private GameObject[,] dessertTiles;

    public bool isShifting { get; set; }

    private void Awake()
    {
        gridManagerInstance = this;
    }

    private void Start()
    {
        Vector2 offset = dessertTile.GetComponent<SpriteRenderer>().bounds.size;
        MakeGrid(offset.x, offset.y);
    }

    public void MakeGrid(float xOffset, float yOffset)
    {
        dessertTiles = new GameObject[xSize, ySize];

        float startX = transform.position.x;
        float startY = transform.position.y;


        for(int x = 0; x < xSize; x++)
        {
            for(int y= 0; y < ySize; y++)
            {
                GameObject newDessert = Instantiate(dessertTile,
                    new Vector3(startX + (xOffset * x),  startY + (yOffset * y), 0),
                    dessertTile.transform.rotation);

                dessertTiles[x, y] = newDessert;
                newDessert.transform.parent = transform;
            }
        }
    }
}


