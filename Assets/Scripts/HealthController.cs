using System;
using UnityEngine;
using UnityEngine.UI;


public class HealthController : MonoBehaviour
{
    [SerializeField] private Image[] health;
    public int playerHealth = 3;

    private void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        for(int i = 0; i < health.Length; i++)
        {
            if (i < playerHealth)
            {
                health[i].color = Color.red;
            } else
            {
                health[i].color = Color.clear;
            }
        }
    }
}
