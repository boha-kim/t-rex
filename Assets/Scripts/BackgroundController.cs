using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;

    private float tileWidth;
    private List<Tile> tileList;

    private void Awake()
    {
        if (tilePrefab != null)
        {
            var sprite = tilePrefab.GetComponent<SpriteRenderer>().sprite;
            tileWidth = sprite.rect.width / sprite.pixelsPerUnit;
        }

        tileList = new List<Tile>();
    }

    private void Start()
    {
        foreach(var tile in this.GetComponentsInChildren<Tile>())
        {
            tileList.Add(tile);
            tile.backgroundController = this;
        }
    }

    private void FixedUpdate()
    {
        // check first tile
        if (tileList[0].transform.position.x <= -tileWidth)
        {
            var lastTile = tileList[tileList.Count - 1];
            Tile newTile = RebuildTile();
            newTile.transform.position = new Vector3(lastTile.transform.position.x + tileWidth, newTile.transform.position.y);
        }
    }

    public Tile RebuildTile()
    {
        Tile tempTile = tileList[0];
        tileList.RemoveAt(0);
        tileList.Add(tempTile);

        return tempTile;
    }
}
