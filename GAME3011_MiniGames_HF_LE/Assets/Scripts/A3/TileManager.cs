using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private Color selectedColor = new Color(.5f, .5f, .5f, 1.0f);
    private static TileManager previousSelected = null;

    private SpriteRenderer render;
    private bool isSelected = false;

    private Vector2[] adjacentDirections = new Vector2[] { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

    void Awake()
    {
        render = GetComponent<SpriteRenderer>();
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
                SwapSprite(previousSelected.render);
                previousSelected.Deselect(); // 4
            }
        }
    }

    public void SwapSprite(SpriteRenderer render2)
    { // 1
        if (render.sprite == render2.sprite)
        { // 2
            return;
        }

        Sprite tempSprite = render2.sprite; // 3
        render2.sprite = render.sprite; // 4
        render.sprite = tempSprite; // 5
    }

    /*void OnMouseDown()
    {
        // 1
        if (render.sprite == null || GridManager.gridManagerInstance.isShifting)
        {
            return;
        }

        if (isSelected)
        {
            Deselect();
        }
        else
        {
            if (previousSelected == null)
            { 
                Select();
            }
            else
            {
                //SwapSprite(previousSelected.render);
                //previousSelected.Deselect(); // 4

                if (GetAllAdjacentTiles().Contains(previousSelected.gameObject))
                { // 1
                    SwapSprite(previousSelected.render); // 2
                    previousSelected.Deselect();
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
            return hit.collider.gameObject;
        }
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
    }*/

}
