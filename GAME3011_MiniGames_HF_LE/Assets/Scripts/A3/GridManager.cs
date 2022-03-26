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

        Sprite[] previousLeft = new Sprite[ySize];
        Sprite previousBelow = null;

        for (int x = 0; x < xSize; x++)
        {
            for(int y= 0; y < ySize; y++)
            {
                GameObject newDessert = Instantiate(dessertTile,
                    new Vector3(startX + (xOffset * x),  startY + (yOffset * y), 0),
                    dessertTile.transform.rotation);

                dessertTiles[x, y] = newDessert;
                newDessert.transform.parent = transform;
                newDessert.GetComponent<SpriteRenderer>().sortingOrder = 1;

                List<Sprite> possibleCharacters = new List<Sprite>();
                possibleCharacters.AddRange(desserts);

                possibleCharacters.Remove(previousLeft[y]);
                possibleCharacters.Remove(previousBelow);

                Sprite newSprite = possibleCharacters[Random.Range(0, possibleCharacters.Count)];

                newDessert.GetComponent<SpriteRenderer>().sprite = newSprite; // picks a random sprite from dessert list and assigns it to the DessertTile prefab
                newDessert.name = ($"Dessert [{x},{y}]");

                previousLeft[y] = newSprite;
                previousBelow = newSprite;
            }
        }
    }
}


