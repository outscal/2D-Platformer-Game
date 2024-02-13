using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameManager gameManager;
    public int maxHealth = 10;
    public int health;
    public SpriteRenderer playersr;
    public NewBehaviourScript playerMovement;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        health -= damage;
      //  ReloadLevel();//AS OF NOW
        if (health<=0 && !isDead)
        {
            isDead = true;
            playersr.enabled = false;
            playerMovement.enabled = false;
            gameManager.gameOver();
            SceneManager.LoadScene(2);
        }
    }
   // private void ReloadLevel()
    //{
      //  SceneManager.LoadScene(0);
   // }
}
