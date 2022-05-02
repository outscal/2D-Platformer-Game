using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int playerHealth; 
    [SerializeField] private Image[] hearts;
    public PlayerController playerController;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if(playerHealth <= 0)
        {
            //Debug.Log("Player Death Animation is playing");
            //playerController = gameObject.GetComponent<PlayerController>();
            playerController.playerDeathAnimation();
            //FindObjectOfType<LevelManager>(). RestartLevel();
        }
        if (playerHealth > hearts.Length)
        {
            playerHealth = hearts.Length;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < playerHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < hearts.Length)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

}
