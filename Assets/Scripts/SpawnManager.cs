using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    private void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
        SpawingPlayer();
    }
    private void SpawingPlayer()
    {
        Debug.Log("SpawingPlayer");
        Instantiate(Player, gameObject.transform.position, Quaternion.identity);
    }
}
