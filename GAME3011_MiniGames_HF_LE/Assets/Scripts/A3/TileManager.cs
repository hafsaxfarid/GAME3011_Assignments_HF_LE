using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    public int row;
    
    [SerializeField]
    public int column;

    private Color selectedColor = new Color(.5f, .5f, .5f, 1.0f);
    private static TileManager previousSelected = null;

    private SpriteRenderer render;
    private bool isSelected = false;

    private Vector2[] adjacentDirections = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };
    private bool matchFound = false;
    List<GameObject> adjacentTiles;


    public void setGridCoords(int r, int c)
    {
        row = r;
        column = c;
    }

    void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ClearAllMatches();
    }

    private void Select()
    {
        isSelected = true;
        render.color = selectedColor;
        previousSelected = gameObject.GetComponent<TileManager>();
    }

    private void Deselect()
    {
        isSelected = false;
        render.color = Color.white;
        previousSelected = null;
    }

    void OnMouseDown()
    {
        // 1
        if (render.sprite == null || GridManager.gridManagerInstance.isShifting)
        {
            return;
        }

        if (isSelected)
        { // 2 Is it already selected?
            Deselect();
        }
        else
        {
            if (previousSelected == null)
            { // 3 Is it the first tile selected?
                Select();
            }
            else
            {
                if (GetAllAdjacentTiles().Contains(previousSelected.gameObject))
                { // 1
                    SwapSprite(previousSelected.render); // 2
                    previousSelected.ClearAllMatches();
                    previousSelected.Deselect();
                    ClearAllMatches();
                }
                else
                { // 3
                    previousSelected.GetComponent<TileManager>().Deselect();
                    Select();
                }
            }
        }
    }

    public void SwapSprite(SpriteRenderer render2)
    {
        if (render.sprite == render2.sprite)
        {
            return;
        }

        Sprite tempSprite = render2.sprite;
        render2.sprite = render.sprite;
        render.sprite = tempSprite;
    }

    private GameObject GetAdjacent(Vector2 castDir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir);
        if (hit.collider != null)
        {
            Debug.Log("raycast");
            return hit.collider.gameObject;
        }
        Debug.Log("raycast no");
        return null;
    }

    private List<GameObject> GetAllAdjacentTiles()
    {
        List<GameObject> adjacentTiles = new List<GameObject>();
        for (int i = 0; i < adjacentDirections.Length; i++)
        {
            adjacentTiles.Add(GetAdjacent(adjacentDirections[i]));
        }
        return adjacentTiles;
    }

    private List<GameObject> FindMatch(Vector2 castDir)
    { // 1
        List<GameObject> matchingTiles = new List<GameObject>(); // 2
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir); // 3
        while (hit.collider != null && hit.collider.GetComponent<SpriteRenderer>().sprite == render.sprite)
        { // 4
            matchingTiles.Add(hit.collider.gameObject);
            hit = Physics2D.Raycast(hit.collider.transform.position, castDir);
        }
        return matchingTiles; // 5
    }

    private void ClearMatch(Vector2[] paths) // 1
    {
        List<GameObject> matchingTiles = new List<GameObject>(); // 2
        for (int i = 0; i < paths.Length; i++) // 3
        {
            matchingTiles.AddRange(FindMatch(paths[i]));
        }


        if(GameManagerA3.easy)
        {
            if (matchingTiles.Count == 2) // 4
            {
                for (int i = 0; i < matchingTiles.Count; i++) // 5
                {
                    matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;
                }
                matchFound = true; // 6
            }
        }

        if (GameManagerA3.medium)
        {
            if (matchingTiles.Count == 3) // 4
            {
                for (int i = 0; i < matchingTiles.Count; i++) // 5
                {
                    matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;
                }
                matchFound = true; // 6
            }
        }

        if (GameManagerA3.hard)
        {
            if (matchingTiles.Count == 4) // 4
            {
                for (int i = 0; i < matchingTiles.Count; i++) // 5
                {
                    matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;
                }
                matchFound = true; // 6
            }
        }
    }

    public void ClearAllMatches()
    {
        if (render.sprite == null)
            return;

        ClearMatch(new Vector2[2] { Vector2.left, Vector2.right });
        ClearMatch(new Vector2[2] { Vector2.up, Vector2.down });
        if (matchFound)
        {
            render.sprite = null;
            matchFound = false;

            StopCoroutine(GridManager.gridManagerInstance.FindNullTiles());
            StartCoroutine(GridManager.gridManagerInstance.FindNullTiles());

            //SFXManager.instance.PlaySFX(Clip.Clear);
        }
    }
}
