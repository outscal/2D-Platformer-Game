using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   private float health = 0f;
   [SerializeField] private float maxHealth = 100f;

   public Slider HealthBar;
   public static bool gameOver;
   

   private void Start() 
   {
       health = maxHealth;
       gameOver = false;
       
   }

   public void UpdateHealth(float mod)
   {
       HealthBar.value = health;
       health += mod;

       if (health > maxHealth)
       {
           health = maxHealth;
       }
       else if (health <= 0)
       {
          
           health = 0f;
           
           gameOver = true;

           //Debug.Log("Player");
       }
       
   }
}
