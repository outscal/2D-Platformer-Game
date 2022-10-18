using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    public int playerHealth;
    [SerializeField]
    private Image[] _hearts;
    public Animator anim;
    public GameOverController gameOverController;
    private void Start()
    {

        UpdateHealth();
    }
    public void UpdateHealth()
    {
     
        if(playerHealth <= 0)
        {
            anim.SetTrigger("isDead");
            gameOverController.PlayerDied();
        }
        else
        {
           
            for (int i = 0; i < _hearts.Length; i++)
            {
                if (i < playerHealth)
                {
                    _hearts[i].color = Color.red;
                }
                else if(i >= playerHealth)
                {
                    _hearts[i].color = Color.black;
                }
                
            }
        }
       
    }
}
