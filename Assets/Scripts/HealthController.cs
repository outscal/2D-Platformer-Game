using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a HEALTH Controller script for the player gameObject. 
/// The player has 3 hearts as health. On colliding with enemy the heart will decrease by 1.
/// If the number of hearts or health becomes 0 then player dies. 
/// Scene gets restarted when player dies and this function is implemented in the PlayerController script and called from the current health controller script. 
/// </summary>
/// 
public class HealthController : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int numOfHearts;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;


    private void Update()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }


    public void EnemyAttack()
    {
        health -= 1;
        if (health == 0)
        {
            PlayerController playerController = gameObject.GetComponent<PlayerController>();
            playerController.PlayerDead();
        }
    }
}
