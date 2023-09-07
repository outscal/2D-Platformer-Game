using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject Player;

    private void Awake()
    {
        SpawingPlayer();
    }
    private void SpawingPlayer()
    {
        Debug.Log("SpawingPlayer");
        Instantiate(Player, gameObject.transform.position, Quaternion.identity);
    }
}
