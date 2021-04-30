using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public PlayerController playerController;

    public int health;
    public int numOfHearts;

    private bool dead;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    
    
    private void Update()   
    {
        if (health > numOfHearts) 
        {
            health = numOfHearts;
        }

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

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            if(dead == true)
            {
                SoundManager.Instance.Play(Sounds.PlayerDeath);
                playerController.KillPlayer();
            }
        }



    }

    public void TakeDamage(int damage)
    {  

        health -= damage;
        if (health < 1)
        {
            dead = true;
        }
    }
}


