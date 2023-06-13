using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;

public class TileTest : MonoBehaviour
{
    private BoundsInt area;
    public Tilemap ground;
    public Tile groundTile;
    public GameObject test;

    private void Start()
    {
        area = ground.cellBounds;
        Spawn();
    }

    private void Spawn()
    {
        List<Vector3Int> availablePositions = new List<Vector3Int>();

        // Find all positions within the bounds that contain the ground tile
        foreach (Vector3Int position in area.allPositionsWithin)
        {
            if (ground.GetTile(position) == groundTile)
            {
                Vector3Int offsetPosition = new Vector3Int(position.x, position.y + 1, position.z);
                availablePositions.Add(offsetPosition);
            }
        }

        // If there are available positions, select a random position and spawn the object
        if (availablePositions.Count > 0)
        {
            int randomIndex = Random.Range(0, availablePositions.Count);
            Vector3Int randomPosition = availablePositions[randomIndex];
            Vector3 cellPosition = ground.GetCellCenterWorld(randomPosition);
            Instantiate(test, cellPosition, Quaternion.identity);
        }
    }
}
