using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelComplete : MonoBehaviour
{
    [SerializeField] private string CurScene;
    [SerializeField] private GameObject gameCompletCanvas;
    [SerializeField] private GameObject heartCanvas;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            NextScene();
        }

    }

    private void NextScene()
    {
        //LevelManager.Instacne.MarkCurrentLevelComplete();
        gameCompletCanvas.SetActive(true);
        heartCanvas.SetActive(false);
        
    }
}
