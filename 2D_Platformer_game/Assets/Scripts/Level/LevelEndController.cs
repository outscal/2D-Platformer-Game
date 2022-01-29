using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndController : MonoBehaviour
{
    public GameObject levelEndUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
           LevelManager.Instance.MarkCurrentLevelComplete();
           levelEndUI.SetActive(true);
        }
    }
}
