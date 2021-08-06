using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D box2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
     
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("level Complete");
            SceneManager.LoadScene("S1");
        }
    }
}
