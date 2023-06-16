using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    private BoundsInt area;
    [SerializeField] private Tilemap ground;
    [SerializeField] private Tile groundTile;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private GameObject[] patrolPoints;

    private void Start()
    {
        area = ground.cellBounds;
        Spawn();
    }

    private void Spawn()
    {
        List<Vector3Int> availablePositions = new List<Vector3Int>();

        foreach (Vector3Int position in area.allPositionsWithin)
        {
            if (ground.GetTile(position) == groundTile)
            {
                Vector3Int offsetPosition = new Vector3Int(position.x, position.y + 1, position.z);
                availablePositions.Add(offsetPosition);
            }
        }

        Vector3Int pos1 = availablePositions[0];
        Vector3Int pos2 = availablePositions[availablePositions.Count - 1];

        Vector3 patrolCell1 = ground.GetCellCenterWorld(pos1);
        Vector3 patrolCell2 = ground.GetCellCenterWorld(pos2);

        Instantiate(patrolPoints[0], patrolCell1, Quaternion.identity);
        Instantiate(patrolPoints[1], patrolCell2, Quaternion.identity);

        if (availablePositions.Count >= prefabs.Length)
        {
            for (int i = 0; i < prefabs.Length; i++)
            {
                Vector3Int randomPosition = GetDistinctPosition(availablePositions);
                Vector3 cellPosition = ground.GetCellCenterWorld(randomPosition);
                GameObject spawnedObject = Instantiate(prefabs[i], cellPosition, Quaternion.identity);

                if (prefabs[i].GetComponent<LevelDone>() != null)
                {
                    Vector3 spawnPosition = spawnedObject.transform.position;
                    spawnPosition.y -= 1;
                    spawnedObject.transform.position = spawnPosition;
                }
            }
        }
    }

    private Vector3Int GetDistinctPosition(List<Vector3Int> positions)
    {
        int randomIndex = Random.Range(0, positions.Count);
        Vector3Int randomPosition = positions[randomIndex];
        positions.RemoveAt(randomIndex);
        return randomPosition;       
    }
}
