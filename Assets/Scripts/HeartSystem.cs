using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public int playerHealth;
    public int health;
    [SerializeField] private Image[] hearts;
    private void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
       for (int i= 0; i < hearts.Length; i++)
       {
            
                if (i < playerHealth)
                {
                    hearts[i].color = Color.red;
                }
                else
                {
                    hearts[i].color = Color.black;
                }
       }
        
    }
}
