
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class PlayerHealth : MonoBehaviour
//{
//    public int health;
//    public int numOfHearts;
//    public PlayerController playercontroller;

//    public Image[] hearts;
//    public Sprite fullHeart;
//    public Sprite emptyHeart;
//    private void Update()
//    {
//        numOfHearts = playercontroller.playerHealth;
//        for (int i = 0; i < hearts.Length; i++)
//        {
//            if(i<numOfHearts)
//            {
//                hearts[i].enabled = true;
//            }
//            else
//            {
//                hearts[i].enabled = false;
//            }
//        }
//    }
//}   
