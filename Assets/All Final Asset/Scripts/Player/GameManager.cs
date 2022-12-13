using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
   [SerializeField] private GameObject [] hearths;
   [SerializeField] private GameObject GameOverCanvas;
   [SerializeField] private GameObject HeartCanvas;
   

   private void Awake()
   {
   
    GameOverCanvas.SetActive(false);
    HeartCanvas.SetActive(true);
    for(int i = 0; i<hearths.Length;i++)
    {
        hearths[i].SetActive(true);
    }
   }
   public void HealthHearts(int health)
   {
        if(health > hearths.Length)
        {
            health = hearths.Length;
        }
        if(health > 0)
        {
            hearths[(hearths.Length - health - 1)].SetActive(false);
            
        }
        else
        {
            Invoke(nameof(EnableGameOver),0.5f);
        }
   }
   public void EnableGameOver()
   {
    HeartCanvas.SetActive(false);
    GameOverCanvas.SetActive(true);
    
   }
}
