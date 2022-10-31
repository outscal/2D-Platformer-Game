using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    [SerializeField] GameObject Game_Over_screen;
    [SerializeField] GameObject UI;





    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        Game_Over_screen.SetActive(false);
        UI.SetActive(true);
    }
    public void TakeDamage(float _damage)
    {
        

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
           
            //iframes
        }
        
        else
        {
            GetComponent<MoveMent_blend>().enabled = false;
            if (currentHealth <=0)
            {
                
                anim.SetTrigger("die");
                UI.SetActive(false);
                
                Invoke("Game_over", 2f);
              


            }
        }
    }
    void Game_over()
    {
        
       Game_Over_screen.SetActive(true);
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
