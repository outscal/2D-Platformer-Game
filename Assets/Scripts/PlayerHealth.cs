using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Player Health
    public int health;
    public int maxHealth = 5;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        //Player Health
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health == 0)
        {
            playerController.KillPlayer();

        }
    }


 }
