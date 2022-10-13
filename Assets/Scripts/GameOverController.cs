using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        HealthSystem.OnPlayerDeath += EnableGameOverMenu;
    }
    private void OnDisable()
    {
        HealthSystem.OnPlayerDeath -= EnableGameOverMenu;
    }
    public void EnableGameOverMenu() 
    {
        gameOverMenu.SetActive(true);
    }
}
