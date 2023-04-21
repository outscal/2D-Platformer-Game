using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static int health;
    public int numofHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    

    void Awake()
    {
        health = 3;
    }





    void Update()
    {
         for  (int i= 0; i < hearts.Length; i++ )
         {

           if (i < health )
           {
              hearts[i].sprite = fullHeart;
           }
           else
           {
              hearts[i].sprite = emptyHeart;
           }


            if (i < numofHearts)
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
