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
    private bool matchFound = false;
    List<GameObject> adjacentTiles;

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
                if (GetAllAdjacentTiles().Contains(previousSelected.gameObject))
                {
                    SwapSprite(previousSelected.render);
                    previousSelected.ClearAllMatches();
                    previousSelected.Deselect();
                    ClearAllMatches();
                }
                else
                {
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
    }

    private List<GameObject> FindMatch(Vector2 castDir)
    {
        List<GameObject> matchingTiles = new List<GameObject>();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir);
        
        while (hit.collider != null && hit.collider.GetComponent<SpriteRenderer>().sprite == render.sprite)
        {
            matchingTiles.Add(hit.collider.gameObject);
            hit = Physics2D.Raycast(hit.collider.transform.position, castDir);
        }
        return matchingTiles;
    }

    private void ClearMatch(Vector2[] paths)
    {
        List<GameObject> matchingTiles = new List<GameObject>();
        for (int i = 0; i < paths.Length; i++)
        {
            matchingTiles.AddRange(FindMatch(paths[i]));
        }


        if(GameManagerA3.easy)
        {
            if (matchingTiles.Count == 2)
            {
                GameManagerA3.gmA3Instance.clearSFX.PlayOneShot(GameManagerA3.gmA3Instance.matchSFX);

                for (int i = 0; i < matchingTiles.Count; i++)
                {
                    matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;
                }
                matchFound = true;

                if (GameManagerA3.gmA3Instance.score != GameManagerA3.gmA3Instance.scoreToEarn)
                {
                    GameManagerA3.gmA3Instance.score += 5;
                    GameManagerA3.gmA3Instance.scoreText.text = (GameManagerA3.gmA3Instance.score.ToString() +
                        " / " + GameManagerA3.gmA3Instance.scoreToEarn.ToString());
                }
                if(GameManagerA3.gmA3Instance.score == GameManagerA3.gmA3Instance.scoreToEarn)
                {
                    GameManagerA3.gmA3Instance.GameWin();
                }
            }
        }

        if (GameManagerA3.medium)
        {
            if (matchingTiles.Count == 3)
            {
                GameManagerA3.gmA3Instance.clearSFX.PlayOneShot(GameManagerA3.gmA3Instance.matchSFX);
                for (int i = 0; i < matchingTiles.Count; i++)
                {
                    matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;
                }
                matchFound = true;

                if (GameManagerA3.gmA3Instance.score != GameManagerA3.gmA3Instance.scoreToEarn)
                {
                    GameManagerA3.gmA3Instance.score += 10;
                    GameManagerA3.gmA3Instance.scoreText.text = (GameManagerA3.gmA3Instance.score.ToString() +
                        " / " + GameManagerA3.gmA3Instance.scoreToEarn.ToString());
                }
                if (GameManagerA3.gmA3Instance.score == GameManagerA3.gmA3Instance.scoreToEarn)
                {
                    GameManagerA3.gmA3Instance.GameWin();
                }
            }
        }

        if (GameManagerA3.hard)
        {
            if (matchingTiles.Count == 4)
            {
                GameManagerA3.gmA3Instance.clearSFX.PlayOneShot(GameManagerA3.gmA3Instance.matchSFX);
                for (int i = 0; i < matchingTiles.Count; i++)
                {
                    matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;
                }
                matchFound = true;

                if (GameManagerA3.gmA3Instance.score != GameManagerA3.gmA3Instance.scoreToEarn)
                {
                    GameManagerA3.gmA3Instance.score += 15;
                    GameManagerA3.gmA3Instance.scoreText.text = (GameManagerA3.gmA3Instance.score.ToString() +
                        " / " + GameManagerA3.gmA3Instance.scoreToEarn.ToString());
                }
                if (GameManagerA3.gmA3Instance.score == GameManagerA3.gmA3Instance.scoreToEarn)
                {
                    GameManagerA3.gmA3Instance.GameWin();
                }
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
            GameManagerA3.gmA3Instance.clearSFX.PlayOneShot(GameManagerA3.gmA3Instance.matchSFX);
            render.sprite = null;
            matchFound = false;

            StopCoroutine(GridManager.gridManagerInstance.FindNullTiles());
            StartCoroutine(GridManager.gridManagerInstance.FindNullTiles());
        }
    }
}
