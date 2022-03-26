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
    public bool isShifting { get; set; }

    private GameObject[,] dessertTiles;
    private TileManager tile;

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

	public IEnumerator FindNullTiles()
	{
		for (int x = 0; x < xSize; x++)
		{
			for (int y = 0; y < ySize; y++)
			{
				if (dessertTiles[x, y].GetComponent<SpriteRenderer>().sprite == null)
				{
					yield return StartCoroutine(ShiftTilesDown(x, y));
					break;
				}
			}
		}

		for (int x = 0; x < xSize; x++)
		{
			for (int y = 0; y < ySize; y++)
			{
				dessertTiles[x, y].GetComponent<TileManager>().ClearAllMatches();
			}
		}
	}

	private IEnumerator ShiftTilesDown(int x, int yStart, float shiftDelay = .03f)
	{
		isShifting = true;
		List<SpriteRenderer> renders = new List<SpriteRenderer>();
		int nullCount = 0;

		for (int y = yStart; y < ySize; y++)
		{  // 1
			SpriteRenderer render = dessertTiles[x, y].GetComponent<SpriteRenderer>();
			if (render.sprite == null)
			{ // 2
				nullCount++;
			}
			renders.Add(render);
		}

		for (int i = 0; i < nullCount; i++)
		{ // 3
			yield return new WaitForSeconds(shiftDelay);// 4
			for (int k = 0; k < renders.Count - 1; k++)
			{ // 5
				renders[k].sprite = renders[k + 1].sprite;
				renders[k + 1].sprite = GetNewSprite(x, ySize - 1);
			}
		}
		isShifting = false;
	}

	private Sprite GetNewSprite(int x, int y)
	{
		List<Sprite> possibleCharacters = new List<Sprite>();
		possibleCharacters.AddRange(desserts);

		if (x > 0)
		{
			possibleCharacters.Remove(dessertTiles[x - 1, y].GetComponent<SpriteRenderer>().sprite);
		}
		if (x < xSize - 1)
		{
			possibleCharacters.Remove(dessertTiles[x + 1, y].GetComponent<SpriteRenderer>().sprite);
		}
		if (y > 0)
		{
			possibleCharacters.Remove(dessertTiles[x, y - 1].GetComponent<SpriteRenderer>().sprite);
		}

		return possibleCharacters[Random.Range(0, possibleCharacters.Count)];
	}
}


